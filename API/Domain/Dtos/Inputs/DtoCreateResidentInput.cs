using Domain.Dtos.Helps;

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
    }
}
