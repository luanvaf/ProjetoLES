using Domain.Dtos.Helps;
using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Dtos.Inputs
{
    public class DtoCreateResidentInput : DtoCreateUserInput
    {
        public DtoCreateResidentInput()
        {
            this.Role = DtoUserRoleType.Resident;
        }
        /// <summary>
        /// Ano de residencia
        /// </summary>
        public DtoResidenceYearType ResidenceYear { get; set; }
        public override User ToUser()
        {
            return new Resident
            {
                Name = this.CompleteName,
                Password = this.Password,
                Login = this.Login,
                ResidenceYear = (ResidenceYear)this.ResidenceYear,
                Crm = this.Crm,
                RoleId = (UserRoleType)this.Role
            };

        }
    }
}
