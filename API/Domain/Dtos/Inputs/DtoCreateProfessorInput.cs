using Domain.Dtos.Helps;
using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Dtos.Inputs
{
    public class DtoCreateProfessorInput : DtoCreateUserInput
    {
        public DtoCreateProfessorInput()
        {
            this.Role = DtoUserRoleType.Professor;
        }
        /// <summary>
        /// Titulação
        /// </summary>
        public string Titulation { get; set; }
        public override User ToUser()
        {
            return new Professor
            {
                Name = this.CompleteName,
                Password = this.Password,
                Titulation = this.Titulation,
                Crm = this.Crm,
                RoleId = (UserRoleType)this.Role
            };
        }
    }
}
