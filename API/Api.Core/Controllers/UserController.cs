using Domain.Dtos.Inputs;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Rnc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ICreateUserService _createUserService;
        public UserController(ICreateUserService createUserService)
        {
            _createUserService = createUserService;
        }
        /// <summary>
        /// Endpoint responsável pela criação do residente
        /// </summary>
        /// <param name="dtoCreateResidentInput"></param>
        /// <returns></returns>
        [HttpPost("resident")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateResident([FromBody] DtoCreateResidentInput dtoCreateResidentInput)
        {
            var createUserServiceResponse = await _createUserService.Execute(dtoCreateResidentInput);
            if (createUserServiceResponse.Success)
                return Ok();
            else
                return BadRequest(createUserServiceResponse.Message);
        }
        /// <summary>
        /// Endpoint responsável pela criação do professor
        /// </summary>
        /// <param name="dtoCreateProfessorInput"></param>
        /// <returns></returns>
        [HttpPost("professor")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateProfessor([FromBody] DtoCreateProfessorInput dtoCreateProfessorInput)
        {
            var createUserServiceResponse = await _createUserService.Execute(dtoCreateProfessorInput);
            if (createUserServiceResponse.Success)
                return Ok();
            else
                return BadRequest(createUserServiceResponse.Message);
        }

        /// <summary>
        /// Endpoint responsável pela criação do medico
        /// </summary>
        /// <param name="dtoCreateDoctorInput"></param>
        /// <returns></returns>
        [HttpPost("doctor")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateDoctor([FromBody] DtoCreateDoctorInput dtoCreateDoctorInput)
        {
            var createUserServiceResponse = await _createUserService.Execute(dtoCreateDoctorInput);
            if (createUserServiceResponse.Success)
                return Ok();
            else
                return BadRequest(createUserServiceResponse.Message);
        }
    }
}
