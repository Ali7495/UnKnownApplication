using Identity.Application.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.ExceptionHandling
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionHandlerMiddleware> _logger;

        public CustomExceptionHandlerMiddleware(RequestDelegate next, ILogger<CustomExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            string message = string.Empty;

            ApiResultStatusCode apiResultStatusCode = ApiResultStatusCode.ServerError;
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;

            context.Request.EnableBuffering();

            context.Request.Body.Seek(0, SeekOrigin.Begin);

            try
            {
                await _next(context);
            }
            catch (BadRequestException exception)
            {
                _logger.LogError(exception,exception.Message);
            }
        }
    }
}
