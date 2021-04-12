using Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using Service.Services;

namespace Api.Core.Extensions
{
    /// <summary>
    /// Classe criada para realizar a Injeção de dependencia nos services.
    /// </summary>
    /// <returns></returns>
    public static class ServicesInjectionsExtensions
    {
        /// <summary>
        /// Realizar a Injeção de dependencia nos services.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddServicesInjections(this IServiceCollection services)
        {
            services.AddScoped<ICreateUserService, CreateUserService>();
            services.AddScoped<ICreateAuthService, CreateAuthService>();
            services.AddScoped<IAddMedicalConsultationService, AddMedicalConsultationService>();
            services.AddScoped<ICreateMedicalReportService, CreateMedicalReportService>();
            services.AddScoped<IAddMedicalEquipamentService, AddMedicalEquipamentService>();
            services.AddScoped<IScheduleExamService, ScheduleExamService>();
            services.AddScoped<IEndExamService, EndExamService>();

            return services;
        }
    }
}
