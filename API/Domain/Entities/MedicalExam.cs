using Domain.ValueObjects;
using System;

namespace Domain.Entities
{
    public class MedicalExam : Entity<Guid>
    {
        public DateTime ExamDate { get; set; }
        public ExamStatus ExamStatus { get; set; }
        public string ExamResult { get; set; }
        public Guid DoctorPerfomedExamId { get; set; }
        public Guid MedicalConsultationId { get; set; }
        public Guid MedicalEquipamentId { get; set; }
        public virtual Doctor DoctorPerfomedExam { get; set; }

        public virtual MedicalConsultation MedicalConsultation { get; set; }
        public virtual MedicalEquipament MedicalEquipament{ get; set; }

        public void ValidateStatus()
        {
            if (ExamDate <= DateTime.Now && ExamStatus == ExamStatus.Scheduled)
                ExamStatus = ExamStatus.Unaccomplished;
        }
        public void EndExam(Guid DoctorPerfomedExamId, string result)
        {
            this.DoctorPerfomedExamId = DoctorPerfomedExamId;
            this.ExamResult = result;
            ExamStatus = ExamStatus.Accomplished;
        }
    }
}
