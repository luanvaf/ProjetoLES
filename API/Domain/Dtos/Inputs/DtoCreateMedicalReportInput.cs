using System;

namespace Domain.Dtos.Inputs
{
    public class DtoCreateMedicalReportInput
    {
        public Guid MedicalConsultationId { get; set; }
        public string Report { get; set; }

    }
}
