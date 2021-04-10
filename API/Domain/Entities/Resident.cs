using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Resident : Doctor
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
