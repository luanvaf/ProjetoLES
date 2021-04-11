using AutoMapper;
using Domain.Dtos.Inputs;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;
        public PatientController(IPatientRepository patientRepository, 
                                 IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }
        /// <summary>
        /// Endpoint responsável por retornar todos os pacientes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _patientRepository.GetAllWithIncludes("Address"));
        }
        /// <summary>
        /// Endpoint responsável por retornar paciente pelo cpf
        /// </summary>
        /// <returns></returns>
        [HttpGet("{cpf:length(11)}")]
        public async Task<IActionResult> GetByCPF(string cpf)
        {
            return Ok(await _patientRepository.GetByCPF(cpf));
        }
        /// <summary>
        /// Endpoint responsável por criar o paciente
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] DtoCreatePatientInput dto)
        {
            var patient = _mapper.Map<Patient>(dto);
            var hasPatientWithCpf = await _patientRepository.GetByCPF(dto.Cpf);

            if (hasPatientWithCpf != null)
                return BadRequest("O Paciente já possui cadastrado.");

            var newPatient = await _patientRepository.Insert(patient);

            return Ok(newPatient);
        } 
    }
}
