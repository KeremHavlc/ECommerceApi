using Core.Validator;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace WebApi.Extensions
{
    public static class FluentValidationExtension
    {
        public static IServiceCollection AddCustomValidation(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters()
                .AddValidatorsFromAssemblyContaining<UserValidator>();

            return services;
        }
    }
}
