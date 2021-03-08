using Domain.Dtos.Helps;
using Domain.Entities;

namespace Domain.Dtos.Responses
{
    public class DtoCreateAuthResponse
    {
        public DtoUser User { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
    }
}
