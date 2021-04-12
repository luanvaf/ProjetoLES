using Domain.Dtos.Inputs;
using Domain.Entities;
using Domain.Models.Helps;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IAddMedicalEquipamentService : IService
    {
        Task<ResponseService<MedicalEquipament>> Execute(DtoAddMedicalEquipamentInput equipament);
    }
}
