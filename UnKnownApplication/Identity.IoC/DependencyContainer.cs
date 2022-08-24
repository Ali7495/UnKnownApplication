using Identity.Application.AppServices;
using Identity.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IResponseMessageServices, ResponseMessageServices>();
            services.AddScoped<IIdentityServices, IdentityServices>();
            services.AddScoped<ILogger<IdentityServices>, Logger<IdentityServices>>();
            services.AddScoped<ISignInResultHandler, SignInResultHandler>();
        }
    }
}
