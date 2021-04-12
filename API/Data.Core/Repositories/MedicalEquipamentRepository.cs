using Data.Core.Context;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using System;

namespace Data.Core.Repositories
{
    public class MedicalEquipamentRepository : BaseRepository<MedicalEquipament, Guid> , IMedicalEquipamentRepository
    {
        public MedicalEquipamentRepository(CoreContext context) : base(context)
        {

        }
    }
}
