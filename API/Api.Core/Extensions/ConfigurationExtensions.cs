using Domain.Configs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Api.Core.Extensions
{
    /// <summary>
    /// Extensões de configuração
    /// </summary>
    public static class ConfigurationExtensions
    {
        /// <summary>
        /// Registra as classes de configuração do appsettings para uso injetado com IOptions
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration">provedor de configurações</param>
        /// <returns></returns>
        public static IServiceCollection AddCustomConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<OpenApiInfo>(configuration.GetSection("ApiInfo"));
            services.Configure<CryptographConfig>(configuration.GetSection("CryptographConfig"));

            services.AddHttpClient();

            return services;
        }
    }
}
