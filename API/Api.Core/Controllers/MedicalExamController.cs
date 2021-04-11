using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Api.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalExamController : ControllerBase
    {
        public MedicalExamController()
        {

        }
        
        /// <summary>
        /// Endpoint responsável por obter um exame por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:required}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return await Task.FromResult(Ok());
        }

    }
}
