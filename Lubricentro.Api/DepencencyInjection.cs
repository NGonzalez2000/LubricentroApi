using Lubricentro.Api.Common.Errors;
using Lubricentro.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Lubricentro.Api
{
    public static class DepencencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddMapping();

            services.AddControllers();
            services.AddSingleton<ProblemDetailsFactory, LubricentroProblemDetailsFactory>();
            return services;
        }
    }
}
