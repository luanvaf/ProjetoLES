using Api.Core.Extensions.HealthChecks;
using Data.Core.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Core.Extensions
{
    public static class HealthCheckExtensions
    {
        /// <summary>
        /// Registra as verificações de saúde da api
        /// </summary>
        /// <param name="services"></param>
        public static IServiceCollection AddCustomHealthChecks(this IServiceCollection services)
        {
            services.AddHealthChecks()
                    .AddDbCheck<CoreContext>();

            return services;
        }

        private static IHealthChecksBuilder AddDbCheck<T>(this IHealthChecksBuilder builder)
            where T : DbContext
            => builder.AddCheck<DbConnectionHealthCheck<T>>(typeof(T).Name);
    }
}
