using System;

namespace Domain.Dtos.Inputs
{
    public class DtoScheduleExamInput
    {
        public Guid MedicalConsultationId { get; set; }
        public Guid? MedicalEquipamentId { get; set; }
        public DateTime ExamDate { get; set; }

    }
}
