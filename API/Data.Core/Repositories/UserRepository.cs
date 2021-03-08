using Data.Core.Context;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using System.Threading.Tasks;
using System.Linq;

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
        public async Task<User> GetByCrm(string crm) =>
             await Task.FromResult(_context.Users.FirstOrDefault());
    }
} 
