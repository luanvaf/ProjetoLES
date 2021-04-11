using Domain.Dtos.Inputs;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MedicalConsultationController : ControllerBase
    {
        private readonly IMedicalConsultationRepository _medicalConsultationRepository;
        private readonly IAddMedicalConsultationService _addMedicalConsultationService;
        private readonly ICreateMedicalReportService _createMedicalReportService;
        public MedicalConsultationController(IMedicalConsultationRepository medicalConsultationRepository,
                                             IAddMedicalConsultationService addMedicalConsultationService,
                                             ICreateMedicalReportService createMedicalReportService)
        {
            _medicalConsultationRepository = medicalConsultationRepository;
            _addMedicalConsultationService = addMedicalConsultationService;
            _createMedicalReportService = createMedicalReportService;
        }
        /// <summary>
        /// Endpoint responsável por retornar todas as consultas do paciente
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        [HttpGet("patient/{cpf:length(11)}")]
        public async Task<IActionResult> GetByPatientCPF(string cpf)
        {
            var medicalConsultation = await _medicalConsultationRepository.GetByPatientCPF(cpf);
            return Ok(medicalConsultation);
        }
        /// <summary>
        /// Endpoint responsável por retornar uma consulta por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:required}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _medicalConsultationRepository.GetById(id));
        }
        /// <summary>
        /// Endpoint responsável por adicionar uma nova consulta
        /// </summary>
        /// <param name="medicalConsultation"></param>
        /// <returns></returns>
        [HttpPost("consultation")]
        public async Task<IActionResult> AddMedicalConsultation
            ([FromBody] DtoAddMedicalConsultationInput medicalConsultation)
        {
            var doctorId = Guid.Parse(User.Claims.First(x=>x.Type == "UserId").Value);
            return Created("/{id}", await _addMedicalConsultationService.Execute(doctorId, medicalConsultation));
        }
        [HttpPost("report")]
        public async Task<IActionResult> CreateReport([FromBody] DtoCreateMedicalReportInput report)
        {
            var reportCreatorId = Guid.Parse(User.Claims.First(x => x.Type == "UserId").Value);
            return Created("/{id}", await _createMedicalReportService.Execute(reportCreatorId, report));
        }


    }
}
