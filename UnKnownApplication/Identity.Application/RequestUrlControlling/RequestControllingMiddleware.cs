using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.RequestUrlControlling
{
    public class RequestControllingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestControllingMiddleware> _logger;

        public RequestControllingMiddleware(RequestDelegate next, ILogger<RequestControllingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!context.Request.GetEncodedUrl().Contains("localhost"))
            {
                _logger.LogError("This address is not allowed");
                throw new UnauthorizedAccessException("You are blocked");
            }
            else
            {
                await _next(context);
            }
        }
    }
}
