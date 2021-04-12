using Domain.Dtos.Inputs;
using Domain.Entities;
using Domain.Models.Helps;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IScheduleExamService : IService
    {
        Task<ResponseService<MedicalConsultation>> Execute(DtoScheduleExamInput scheduleInput);
    }
}
