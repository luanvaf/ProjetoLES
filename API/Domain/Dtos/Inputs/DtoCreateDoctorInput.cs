using Domain.Dtos.Helps;
using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Dtos.Inputs
{
    public class DtoCreateDoctorInput : DtoCreateUserInput
    {
        public DtoCreateDoctorInput()
        {
            this.Role = DtoUserRoleType.Doctor;
        }
        public override User ToUser()
        {
            return new Doctor
            {
                Name = this.CompleteName,
                Login = this.Login,
                Password = this.Password,
                Crm = this.Crm,
                RoleId = (UserRoleType)this.Role
            };

        }
    }
}
