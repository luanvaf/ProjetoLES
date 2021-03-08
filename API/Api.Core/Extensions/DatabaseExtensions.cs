using Data.Core.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Api.Core.Extensions
{
    /// <summary>
    /// Configurações de banco de dados
    /// </summary>
    public static class DatabaseExtensions
    {
        /// <summary>
        /// Injeção dos contextos de banco de dados
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = Environment.GetEnvironmentVariable("CONNECTION") ?? configuration.GetConnectionString("CoreContext");
            Console.WriteLine(connection);
            services.AddDbContext<CoreContext>(options =>
                options.UseNpgsql(connection));
            return services;

        }
    }
}
