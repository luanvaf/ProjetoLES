using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public class MedicalConsultation : Entity<Guid>
    {
        public Guid DoctorId { get; set; }
        public DateTime ConsultationDate { get; set; }
        public Guid PatientId { get; set; }
        public virtual ICollection<MedicalExam> MedicalExams { get; set; } = new List<MedicalExam>();
        public virtual Patient Patient { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual MedicalReport Report { get; private set; }


        public bool IsAvailableForMedicalReport()
        {
            MedicalExams.ToList().ForEach(x => x.ValidateStatus());

            return !MedicalExams.Any(x => x.ExamStatus == ExamStatus.Scheduled || x.ExamStatus == ExamStatus.Unaccomplished);
        }

        public void MakeReport(string report, Guid reportCreatorId )
        {
            if (Report != null)
                throw new Exception("A consulta já possui um laudo.");
            if (IsAvailableForMedicalReport())
            {
                Report = new MedicalReport
                {
                    MedicalConsultationId = this.Id,
                    Report = report,
                    ReportCreatorId = reportCreatorId,
                    ReportDate = DateTime.Now,
                    CreatedAt = DateTime.Now
                };
            }
            else
            {
                throw new Exception("Laudo não pode ser feito.");
            }
        }

        public void ScheduleExam(Guid? medicalEquipamentId, DateTime exameDate)
        {
            if (exameDate < DateTime.Now)
                throw new Exception("A data de agendamento do exame é invalida.");
            MedicalExams.Add(new MedicalExam
            {
                MedicalConsultationId = this.Id,
                MedicalEquipamentId = medicalEquipamentId,
                MedicalConsultation = this,
                ExamDate = exameDate,
                ExamStatus = ExamStatus.Scheduled,
            });
        }
    }
}
