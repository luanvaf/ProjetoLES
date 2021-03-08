using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Resident : User
    {
        public Resident()
        {
            this.RoleId = UserRoleType.Resident;
        }
        /// <summary>
        /// Ano de residencia
        /// </summary>
        public ResidenceYear ResidenceYear { get; set; }

    }
}
