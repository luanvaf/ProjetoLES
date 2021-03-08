using Domain.ValueObjects;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class UserRole : Entity<UserRoleType>
    {
        /// <summary>
        /// Tipo do cargo
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Usuários com a permissão
        /// </summary>
        public virtual IEnumerable<User> Users { get; set; }
    }
}
