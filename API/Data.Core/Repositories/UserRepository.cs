using Data.Core.Context;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Data.Core.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly CoreContext _context;
        public UserRepository(CoreContext context) : base(context)
        {
            _context = context;
        }
        /// <summary>
        /// Retorna o usuário pela crm do mesmo 
        /// </summary>
        /// <param name="crm"></param>
        /// <returns></returns>
        public async Task<User> GetByLogin(string login) =>
             await _context.Users.FirstOrDefaultAsync(x => x.Login == login);
    }
} 
