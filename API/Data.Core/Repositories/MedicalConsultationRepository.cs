using Data.Core.Context;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Core.Repositories
{
    public class MedicalConsultationRepository : BaseRepository<MedicalConsultation, Guid>, IMedicalConsultationRepository
    {
        private readonly CoreContext _context;
        public MedicalConsultationRepository(CoreContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IQueryable> GetByPatientCPF(string cpf) 
            => await Task.FromResult(_context.MedicalConsultations.AsNoTracking().Include(x => x.Patient).Where(x => x.Patient.Cpf == cpf));
    }
}
