using Domain.Dtos.Helps;

namespace Domain.Dtos.Inputs
{
    public class DtoCreateDoctorInput : DtoCreateUserInput
    {
        public DtoCreateDoctorInput()
        {
            this.Role = DtoUserRoleType.Doctor;
        }
    }
}
