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
    public class AddMedicalConsultationServiceTests
    {
        private readonly AddMedicalConsultationService _service;
        private readonly Mock<IMedicalConsultationRepository> _mcRepository = new Mock<IMedicalConsultationRepository>();
        private readonly Mock<IUserRepository> _userRepository = new Mock<IUserRepository>();
        private readonly Mock<IPatientRepository> _patientRepository = new Mock<IPatientRepository>();

        public AddMedicalConsultationServiceTests()
        {
            _service = new AddMedicalConsultationService(
                _mcRepository.Object,
                _userRepository.Object,
                _patientRepository.Object
            );
        }

        [Fact]
        public async Task AddMedicalConsultationService_ShouldReturnSuccess_WhenMcIsValid()
        {
            var doctorId = Guid.NewGuid();
            var patientId = Guid.NewGuid();
            var consult = new MedicalConsultation();
            var dto = new DtoAddMedicalConsultationInput
            {
                PatientId = patientId
            };

            var doctor = new Doctor { Id = doctorId };
            var patient = new Patient{ Id = patientId };

            _userRepository.Setup(x => x.GetById(doctorId)).ReturnsAsync(doctor);
            _patientRepository.Setup(x => x.GetById(patientId)).ReturnsAsync(patient);
            _mcRepository.Setup(x => x.Insert(consult)).ReturnsAsync(consult);

            var response = await _service.Execute(doctorId, dto);

            Assert.Equal(HttpStatusCode.OK, response.Status);
        }

        [Fact]
        public async Task AddMedicalConsultationService_ShouldReturnError_WhenMcIsInvalid()
        {
            var doctorId = Guid.NewGuid();
            var patientId = Guid.NewGuid();
            var consult = new MedicalConsultation();
            var dto = new DtoAddMedicalConsultationInput
            {
                PatientId = patientId
            };

            Doctor invalidDoctor = null;
            var patient = new Patient { Id = patientId };

            _userRepository.Setup(x => x.GetById(doctorId)).ReturnsAsync(invalidDoctor);
            _patientRepository.Setup(x => x.GetById(patientId)).ReturnsAsync(patient);
            _mcRepository.Setup(x => x.Insert(consult)).ReturnsAsync(consult);

            var response = await _service.Execute(doctorId, dto);

            Assert.Equal(HttpStatusCode.BadRequest, response.Status);
        }
    }
}
