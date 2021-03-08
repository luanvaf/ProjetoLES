using Domain.Dtos.Inputs;
using Domain.Models.Helps;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface ICreateUserService : IService
    {
        Task<ResponseService> Execute<T>(T createUserInput)
            where T : DtoCreateUserInput;
    }
}
