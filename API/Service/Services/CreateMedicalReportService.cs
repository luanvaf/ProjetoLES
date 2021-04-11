using Domain.Dtos.Inputs;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models.Helps;
using System;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CreateMedicalReportService : AbstractService, ICreateMedicalReportService
    {
        private readonly IMedicalConsultationRepository _medicalConsultationRepository;
        public CreateMedicalReportService(IMedicalConsultationRepository medicalConsultationRepository)
        {
            _medicalConsultationRepository = medicalConsultationRepository;
        }
        public async Task<ResponseService> Execute(Guid reportCreatorId, DtoCreateMedicalReportInput report)
        {
            var medicalConsultation = await _medicalConsultationRepository.GetById(report.MedicalConsultationId);

            if (medicalConsultation == null)
                return GenerateErroServiceResponse("A consulta para laudo não encontrada.");
            try
            {
                medicalConsultation.MakeReport(report.Report, reportCreatorId);

                await _medicalConsultationRepository.Update(medicalConsultation);

                return GenerateSuccessServiceResponse(System.Net.HttpStatusCode.Created);
            }
            catch(Exception ex)
            {
                return GenerateErroServiceResponse(ex.Message);
            }
        }
    }
}
