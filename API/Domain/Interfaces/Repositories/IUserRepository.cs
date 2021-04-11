using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User, Guid>
    {
        Task<User> GetByLogin(string login);
    }
}
