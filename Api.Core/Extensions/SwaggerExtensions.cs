using Api.Core.Extensions.Swagger;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;

namespace Api.Core.Extensions
{
    /// <summary>
    /// Extensões do Swagger
    /// </summary>
    public static class SwaggerExtensions
    {
        /// <summary>
        /// Configuração básica do SwaggerGen
        /// </summary>
        /// <param name="services"></param>
        public static IServiceCollection AddCustomSwaggerGen(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.AddFluentValidationRules();
                c.OperationFilter<BearerAuthenticationFilter>();

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });
            });

            return services;
        }
    }
}
