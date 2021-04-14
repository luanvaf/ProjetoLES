using Domain.Dtos.Inputs;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Moq;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestProject
{
    public class CreateMedicalReportServiceTests
    {
        private readonly CreateMedicalReportService _service;
        private readonly Mock<IMedicalConsultationRepository> _mcRepository = new Mock<IMedicalConsultationRepository>();

        public CreateMedicalReportServiceTests()
        {
            _service = new Service.Services.CreateMedicalReportService(
                _mcRepository.Object
             );
        }

        [Fact]
        public async Task CreateMedicalReportService_ShouldReturnSuccess_WhenReportIsValid()
        {
            var creatorId = Guid.NewGuid();
            var mcId = Guid.NewGuid();
            var report = "mockReport";
            var dto = new DtoCreateMedicalReportInput
            {
                MedicalConsultationId = mcId,
                Report = report
            };
            var mc = new MedicalConsultation { Id = mcId };

            _mcRepository.Setup(x => x.GetById(mcId)).ReturnsAsync(mc);

            var response = await _service.Execute(creatorId, dto);

            Assert.Equal(HttpStatusCode.OK, response.Status);
        }

        [Fact]
        public async Task CreateMedicalReportService_ShouldReturnError_WhenReportIsInvalid()
        {
            var creatorId = Guid.NewGuid();
            var mcId = Guid.NewGuid();
            var report = "mockReport";
            var dto = new DtoCreateMedicalReportInput
            {
                MedicalConsultationId = mcId,
                Report = report
            };
            MedicalConsultation invalidMc = null; 

            _mcRepository.Setup(x => x.GetById(mcId)).ReturnsAsync(invalidMc);

            var response = await _service.Execute(creatorId, dto);

            Assert.Equal(HttpStatusCode.BadRequest, response.Status);
        }
    }
}
