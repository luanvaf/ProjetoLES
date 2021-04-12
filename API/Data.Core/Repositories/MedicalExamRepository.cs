using Data.Core.Context;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using System;

namespace Data.Core.Repositories
{
    public class MedicalExamRepository : BaseRepository<MedicalExam, Guid>, IMedicalExamRepository
    {
        public MedicalExamRepository(CoreContext context) : base(context)
        {

        }
    }
}
