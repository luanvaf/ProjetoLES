using Domain.Dtos.Inputs;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models.Helps;
using System;
using System.Threading.Tasks;

namespace Service.Services
{
    public class EndExamService : AbstractService, IEndExamService
    {
        private readonly IMedicalExamRepository _medicalExamRepository;
        private readonly IUserRepository _userRepository;
        public EndExamService(IMedicalExamRepository medicalExamRepository,
                              IUserRepository userRepository)
        {
            _medicalExamRepository = medicalExamRepository;
            _userRepository = userRepository;
        }

        public async Task<ResponseService<MedicalExam>> Execute(Guid userId, DtoEndExamInput input)
        {
            var exam = await _medicalExamRepository.GetById(input.ExamId);
            if (exam == null)
                return GenerateErroServiceResponse<MedicalExam>("O exame não foi encontrado.");
            try
            {
                exam.EndExam(userId, input.ExamResult);
                await _medicalExamRepository.Update(exam);
                return GenerateSuccessServiceResponse(exam);
            }
            catch(Exception ex)
            {
                return GenerateErroServiceResponse<MedicalExam>(ex.Message);
            }
        }

    }
}
