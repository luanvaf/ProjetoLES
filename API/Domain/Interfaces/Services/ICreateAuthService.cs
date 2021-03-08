using Domain.Dtos.Inputs;
using Domain.Dtos.Responses;
using Domain.Models.Helps;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface ICreateAuthService : IService
    {
        Task<ResponseService<DtoCreateAuthResponse>> Execute(DtoCreateAuthInput dtoCreateAuth);
    }
}
