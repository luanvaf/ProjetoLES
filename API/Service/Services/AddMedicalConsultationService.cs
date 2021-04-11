using Domain.Dtos.Inputs;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models.Helps;
using Service.Adapter;
using System;
using System.Threading.Tasks;

namespace Service.Services
{
    public class AddMedicalConsultationService : AbstractService, IAddMedicalConsultationService
    {
        private readonly IMedicalConsultationRepository _medicalConsultationRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPatientRepository _patientRepository;

        public AddMedicalConsultationService(IMedicalConsultationRepository medicalConsultationRepository,
                                             IUserRepository userRepository,
                                             IPatientRepository patientRepository)
        {
            _medicalConsultationRepository = medicalConsultationRepository;
            _userRepository = userRepository;
            _patientRepository = patientRepository;

        }

        public async Task<ResponseService<MedicalConsultation>> Execute(Guid doctorId, DtoAddMedicalConsultationInput medicalConsultation)
        {
            var doctorExists = await _userRepository.GetById(doctorId);
            if (doctorExists == null)
                return GenerateErroServiceResponse<MedicalConsultation>("O Medico informado não existe.");

            var patientExists = await _patientRepository.GetById(medicalConsultation.PatientId);

            if (patientExists == null)
                return GenerateErroServiceResponse<MedicalConsultation>("O paciente informado não existe.");

            var newConsultation = MedicalConsultationAdapter.CreateMedicalConsultation(
                    patientExists.Id,
                    doctorExists.Id);

            var createdConsultation = await _medicalConsultationRepository.Insert(newConsultation);

            return GenerateSuccessServiceResponse(createdConsultation);
        }
    }
}
