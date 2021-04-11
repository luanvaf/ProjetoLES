using Domain.Dtos.Inputs;
using Domain.Entities;
using Domain.Models.Helps;
using System;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IAddMedicalConsultationService : IService
    {
        Task<ResponseService<MedicalConsultation>> Execute
            (Guid doctorId, DtoAddMedicalConsultationInput medicalConsultation);
    }
}
