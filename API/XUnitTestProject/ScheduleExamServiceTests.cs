using Domain.Dtos.Inputs;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestProject
{
    public class ScheduleExamServiceTests
    {
        private readonly Service.Services.ScheduleExamService _service;
        private readonly Mock<IMedicalConsultationRepository> _mcRepository = new Mock<IMedicalConsultationRepository>();
        private readonly Mock<IMedicalEquipamentRepository> _meRepository = new Mock<IMedicalEquipamentRepository>();


        public ScheduleExamServiceTests()
        {
            _service = new Service.Services.ScheduleExamService(
                _mcRepository.Object,
                _meRepository.Object
             );
        }

        [Fact]
        public async Task ScheduleExamService_ShouldReturnSuccess_WhenExamIsValid()
        {
            var mcId = Guid.NewGuid();
            var meId = Guid.NewGuid();
            var dto = new DtoScheduleExamInput
            {
                MedicalConsultationId = mcId,
                MedicalEquipamentId = meId,
                ExamDate = DateTime.Now.AddDays(1)
            };
            var mc = new MedicalConsultation { Id = mcId };
            var me = new MedicalEquipament { Id = meId };

            _mcRepository.Setup(x => x.GetById(mcId)).ReturnsAsync(mc);
            _meRepository.Setup(x => x.GetById(meId)).ReturnsAsync(me);

            var response = await _service.Execute(dto);

            Assert.Equal(HttpStatusCode.OK, response.Status);
        }

        [Fact]
        public async Task ScheduleExamService_ShouldReturnError_WhenExamIsInvalid()
        {
            var mcId = Guid.NewGuid();
            var meId = Guid.NewGuid();
            var dto = new DtoScheduleExamInput
            {
                MedicalConsultationId = mcId,
                MedicalEquipamentId = meId,
                ExamDate = DateTime.Now.AddDays(-1)
            };
            var mc = new MedicalConsultation { Id = mcId };
            var me = new MedicalEquipament { Id = meId };

            _mcRepository.Setup(x => x.GetById(mcId)).ReturnsAsync(mc);
            _meRepository.Setup(x => x.GetById(meId)).ReturnsAsync(me);

            var response = await _service.Execute(dto);

            Assert.Equal(HttpStatusCode.BadRequest, response.Status);
        }

    }
}
