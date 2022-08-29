using Identity.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.ExceptionHandling
{
    public class BadRequestException : AppException
    {
        public BadRequestException()
            : base(ApiResultStatusCode.BadRequest, HttpStatusCode.BadRequest)
        {
        }

        public BadRequestException(string message)
            : base(ApiResultStatusCode.BadRequest, message, HttpStatusCode.BadRequest)
        {
        }

        public BadRequestException(object additionalData)
            : base(ApiResultStatusCode.BadRequest, HttpStatusCode.BadRequest, additionalData)
        {
        }

        public BadRequestException(string message, object additionalData)
            : base(ApiResultStatusCode.BadRequest, message, HttpStatusCode.BadRequest, additionalData)
        {
        }

        public BadRequestException(string message, Exception exception)
            : base(ApiResultStatusCode.BadRequest, message, HttpStatusCode.BadRequest, exception)
        {
        }

        public BadRequestException(string message, Exception exception, object additionalData)
            : base(ApiResultStatusCode.BadRequest, message, HttpStatusCode.BadRequest, exception, additionalData)
        {
        }
    }
}
