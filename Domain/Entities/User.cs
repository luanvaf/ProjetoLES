using Domain.ValueObjects;
using System;

namespace Domain.Entities
{
    public class User : Entity<Guid>
    {
        /// <summary>
        /// Nome completo
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Crm
        /// </summary>
        public string Crm { get; set; }
        /// <summary>
        /// Senha
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Id da permissão do usuário
        /// </summary>
        public UserRoleType RoleId { get; set; }
        /// <summary>
        /// Dados da permissão do usuário
        /// </summary>
        public virtual UserRole UserRole { get; set; }
    }
}
