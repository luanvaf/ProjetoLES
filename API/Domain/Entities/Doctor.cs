using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Doctor : User
    {
        public Doctor()
        {
            this.RoleId = UserRoleType.Doctor;
        }

        /// <summary>
        /// Crm
        /// </summary>
        public string Crm { get; set; }
    }
}
