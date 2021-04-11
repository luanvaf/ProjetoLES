using Domain.Dtos.Inputs;
using Domain.Models.Helps;
using System;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface ICreateMedicalReportService : IService
    {
        Task<ResponseService> Execute(Guid reportCreatorId, DtoCreateMedicalReportInput report);
    }
}
