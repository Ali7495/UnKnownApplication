using FluentValidation;
using Identity.Application.AppServices;
using Identity.Application.AppServices.PersonServices;
using Identity.Application.DataTransferModels.InputDtos;
using Identity.Application.Interfaces;
using Identity.Application.Interfaces.PersonInterfaces;
using Identity.Application.ModelValidators;
using Identity.Domain.Interfaces;
using Identity.Domain.Interfaces.PersonInterfaces;
using Identity.Infra.Repositories;
using Identity.Infra.Repositories.PersonRepository;
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
            services.AddTransient<IValidator<PersonInputDto>, PersonValidation>();
            services.AddScoped<IResponseMessageServices, ResponseMessageServices>();
            services.AddScoped<IIdentityServices, IdentityServices>();
            services.AddScoped<ILogger<IdentityServices>, Logger<IdentityServices>>();
            services.AddScoped<ISignInResultHandler, SignInResultHandler>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPersonService, PersonService>();
        }
    }
}
