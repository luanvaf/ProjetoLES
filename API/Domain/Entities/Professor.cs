using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Professor : Doctor
    {
        public Professor()
        {
            this.RoleId = UserRoleType.Professor;
        }
        /// <summary>
        /// Titulação
        /// </summary>
        public string Titulation { get; set; }
    }
}
