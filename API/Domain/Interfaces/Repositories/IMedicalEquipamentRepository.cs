using Domain.Entities;
using System;

namespace Domain.Interfaces.Repositories
{
    public interface IMedicalEquipamentRepository : IBaseRepository<MedicalEquipament, Guid>
    {
    }
}
