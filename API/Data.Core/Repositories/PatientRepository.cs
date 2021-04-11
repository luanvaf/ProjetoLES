using Data.Core.Context;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace Data.Core.Repositories
{
    public class PatientRepository : BaseRepository<Patient, Guid>, IPatientRepository
    {
        private readonly CoreContext _context;
        public PatientRepository(CoreContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Patient> GetByCPF([NotNull]string cpf) 
            => await _context.Patient.Include(x=>x.Address).FirstOrDefaultAsync(x => x.Cpf == cpf);
    }
}
