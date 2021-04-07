using Data.Core.Repositories;
using Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Core.Extensions
{
    /// <summary>
    /// Classe criada para realizar a Injeção de dependencia nos repositorios.
    /// </summary>
    /// <returns></returns>
    public static class RepositoriesInjectionsExtensions
    {
        /// <summary>
        /// Realizar a Injeção de dependencia nos repositorios.
        /// </summary>
        /// <returns></returns>
        public static IServiceCollection AddRepositoriesInjections(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            return services;
        }
    }
}
