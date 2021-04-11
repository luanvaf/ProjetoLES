using Data.Core.Context;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Data.Core.Repositories
{
    public class UserRepository : BaseRepository<User, Guid>, IUserRepository
    {
        private readonly CoreContext _context;
        public UserRepository(CoreContext context) : base(context)
        {
            _context = context;
        }
        /// <summary>
        /// Retorna o usuário pela login do mesmo 
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public async Task<User> GetByLogin(string login) =>
             await _context.Users.FirstOrDefaultAsync(x => x.Login == login);
    }
} 
