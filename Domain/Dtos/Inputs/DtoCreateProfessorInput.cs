using Domain.Dtos.Helps;

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
    }
}
