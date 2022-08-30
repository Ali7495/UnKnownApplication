using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.RequestUrlControlling
{
    public static class RequestControllingMiddlewareExtention
    {
        public static IApplicationBuilder UseUnAuthorizedUrlBlockerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestControllingMiddleware>();
        }
    }
}
