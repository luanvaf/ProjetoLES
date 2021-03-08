using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Administrator : User
    {
        public Administrator()
        {
            this.RoleId = UserRoleType.Administrator;
        }
    }
}
