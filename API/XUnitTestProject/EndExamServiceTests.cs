using Domain.Dtos.Inputs;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Moq;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestProject
{
    public class EndExamServiceTests
    {
        private readonly EndExamService _service;
        private readonly Mock<IMedicalExamRepository> _medicalExamRepository = new Mock<IMedicalExamRepository>();
        private readonly Mock<IUserRepository> _userRepository = new Mock<IUserRepository>();


        public EndExamServiceTests()
        {
            _service = new EndExamService(
                _medicalExamRepository.Object,
                _userRepository.Object
            );
        }

        [Fact]
        public async Task EndExamService_ShouldReturnSuccess_WhenExamIsValid()
        {
            var examId = Guid.NewGuid();
            var examResult = "oba";
            var dto = new DtoEndExamInput
            {
                ExamId = examId,
                ExamResult = examResult
            };
            var exam = new MedicalExam
            {
                Id = examId
            };

            _medicalExamRepository.Setup(x => x.GetById(examId)).ReturnsAsync(exam);
            _medicalExamRepository.Setup(x => x.Update(exam)).ReturnsAsync(exam);

            var response = await _service.Execute(examId, dto);

            Assert.Equal(HttpStatusCode.OK, response.Status);
        }

        [Fact]
        public async Task EndExamService_ShouldReturnError_WhenExamIsInvalid()
        {
            var examId = Guid.NewGuid();
            var examResult = "oba";
            var dto = new DtoEndExamInput
            {
                ExamId = examId,
                ExamResult = examResult
            };
            var exam = new MedicalExam
            {
                Id = examId
            };

            MedicalExam exameNaoExistente = null;

            _medicalExamRepository.Setup(x => x.GetById(examId)).ReturnsAsync(exameNaoExistente);
            _medicalExamRepository.Setup(x => x.Update(exam)).ReturnsAsync(exam);

            var response = await _service.Execute(examId, dto);

            Assert.Equal(HttpStatusCode.BadRequest, response.Status);
        }
    }
}
