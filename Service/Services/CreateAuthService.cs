using Domain.Configs;
using Domain.Dtos.Helps;
using Domain.Dtos.Inputs;
using Domain.Dtos.Responses;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Interfaces.Util;
using Domain.Models.Helps;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CreateAuthService : AbstractService, ICreateAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICryptograph _cryptograph;
        private readonly string _jwtSecretKey;
        public CreateAuthService(IUserRepository userRepository,
                                 ICryptograph cryptograph,
                                 IOptions<CryptographConfig> cryptographConfig)
        {
            _userRepository = userRepository;
            _cryptograph = cryptograph;
            _jwtSecretKey = cryptographConfig.Value.JwtSecretKey;
        }
        public async Task<ResponseService<DtoCreateAuthResponse>> Execute(DtoCreateAuthInput dtoCreateAuth)
        {
            var existingAuth = await _userRepository.GetByCrm(dtoCreateAuth.Crm);

            if (existingAuth != null)
            {
                var correctPassword = _cryptograph.VerifyPassword(dtoCreateAuth.Password, existingAuth.Password);

                if (correctPassword)
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_jwtSecretKey);

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {

                                new Claim(ClaimTypes.Name, existingAuth.Name),
                                new Claim(ClaimTypes.Role, existingAuth.RoleId.ToString()),

                        }),
                        Expires = DateTime.UtcNow.AddHours(3),

                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };

                    var token = tokenHandler.CreateToken(tokenDescriptor);

                    var user = new DtoUser
                    {
                        CompleteName = existingAuth.Name,
                        Crm = existingAuth.Crm,
                    };

                    var authResult = new DtoCreateAuthResponse { User = user, Token = tokenHandler.WriteToken(token), Role = existingAuth.RoleId.ToString() };


                    return GenerateSuccessServiceResponse(authResult);
                }
            }
            return GenerateErroServiceResponse<DtoCreateAuthResponse>("Email ou senha invalidos.");
        }
    }
}
