using Domain.Entities;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IPatientRepository : IBaseRepository<Patient, Guid>
    {
        Task<Patient> GetByCPF([NotNull] string cpf);
    }
}
