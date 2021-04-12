using Domain.Dtos.Inputs;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models.Helps;
using System;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ScheduleExamService : AbstractService, IScheduleExamService
    {
        private readonly IMedicalConsultationRepository _medicalConsultationRepository;
        private readonly IMedicalEquipamentRepository _medicalEquipamentRepository;
        public ScheduleExamService(IMedicalConsultationRepository medicalConsultationRepository,
                                   IMedicalEquipamentRepository medicalEquipamentRepository)
        {
            _medicalConsultationRepository = medicalConsultationRepository;
            _medicalEquipamentRepository = medicalEquipamentRepository;
        }

        public async Task<ResponseService<MedicalConsultation>> Execute(DtoScheduleExamInput scheduleInput)
        {
            var medicalConsultation = await _medicalConsultationRepository.GetById(scheduleInput.MedicalConsultationId);

            if (medicalConsultation == null)
                return GenerateErroServiceResponse<MedicalConsultation>("A consulta não foi encontrada.");

            if (scheduleInput.MedicalEquipamentId != null)
            {
                var equipament = await _medicalEquipamentRepository.GetById(scheduleInput.MedicalEquipamentId.Value);
                if (equipament == null)
                    return GenerateErroServiceResponse<MedicalConsultation>("O equipamento informado não foi encontrado.");
            }
            try
            {
                medicalConsultation.ScheduleExam(scheduleInput.MedicalEquipamentId, scheduleInput.ExamDate);
                await _medicalConsultationRepository.Update(medicalConsultation);
                return GenerateSuccessServiceResponse(medicalConsultation);
            }
            catch(Exception ex)
            {
                return GenerateErroServiceResponse<MedicalConsultation>(ex.Message);
            }
        }
    }
}
