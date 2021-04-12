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
    public class MedicalExamController : ControllerBase
    {
        private readonly IScheduleExamService _scheduleExamService;
        private readonly IMedicalExamRepository _medicalExamRepository;
        private readonly IEndExamService _completeExamService;
        public MedicalExamController(IScheduleExamService scheduleExamService,
                                     IMedicalExamRepository medicalExamRepository,
                                     IEndExamService completeExamService)
        {
            _scheduleExamService = scheduleExamService;
            _medicalExamRepository = medicalExamRepository;
            _completeExamService = completeExamService;
        }
        /// <summary>
        /// Endpoint responsável por obter um exame por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:required}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _medicalExamRepository.GetById(id));
        }
        /// <summary>
        /// Endpoint responsável por agendar um exame
        /// </summary>
        /// <param name="schedule"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ScheduleExam([FromBody] DtoScheduleExamInput schedule)
        {
            return Created("api/[controller]/{id}", await _scheduleExamService.Execute(schedule));
        }
        [HttpPost("endExam")]
        public async Task<IActionResult> EndExam([FromBody] DtoEndExamInput input)
        {
            var userId = Guid.Parse(User.Claims.First(x => x.Type == "UserId").Value);

            var responseService = await _completeExamService.Execute(userId, input); 
            if (responseService.Success)
                return Ok(responseService.Value);
            return BadRequest(responseService.Message);
        }
    }
}
