using Domain.Dtos.Inputs;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.ValueObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MedicalEquipamentController : ControllerBase
    {
        private readonly IAddMedicalEquipamentService _addMedicalEquipamentService;
        private readonly IMedicalEquipamentRepository _medicalEquipamentRepository;
        public MedicalEquipamentController(IAddMedicalEquipamentService addMedicalEquipamentService,
                                           IMedicalEquipamentRepository medicalEquipamentRepository)
        {
            _addMedicalEquipamentService = addMedicalEquipamentService;
            _medicalEquipamentRepository = medicalEquipamentRepository;
        }
        /// <summary>
        /// Endpoint responsável por adicionar um novo equipamento aos equipamentos do hospital
        /// </summary>
        /// <param name="equipament"></param>
        /// <returns></returns>
        [Authorize(Roles = nameof(UserRoleType.Administrator))]
        [HttpPost]
        public async Task<IActionResult> AddEquipament(DtoAddMedicalEquipamentInput equipament ) 
        {
            var responseService = await _addMedicalEquipamentService.Execute(equipament);
            if (responseService.Success)
                return Created("api/[controller]/{id}",responseService.Value);

            return BadRequest(responseService.Message);
        }
        /// <summary>
        /// Endpoint responsável por retornar todos os equipamentos do hospital
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _medicalEquipamentRepository.GetAll());
        }
    }
}
