using Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IMedicalConsultationRepository : IBaseRepository<MedicalConsultation, Guid>
    {
        Task<IQueryable<MedicalConsultation>> GetByPatientCPF(string cpf);
    }
}
