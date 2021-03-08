using Domain.Dtos.Inputs;
using Domain.Dtos.Responses;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Rnc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ICreateAuthService _createAuthService;
        public AuthController(ICreateAuthService createAuthService)
        {
            _createAuthService = createAuthService;
        }
        /// <summary>
        /// Endpoint responsável por realizar login
        /// </summary>
        /// <param name="authInput"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(DtoCreateAuthResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login([FromBody] DtoCreateAuthInput authInput)
        {
            var createAuthResponse = await _createAuthService.Execute(authInput);

            if (createAuthResponse.Success)
                return Ok(createAuthResponse.Value);

            return BadRequest(createAuthResponse.Message);
        }
    }
}
