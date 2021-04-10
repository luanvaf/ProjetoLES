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
        public virtual List<MedicalExam> MedicalExams { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual MedicalReport Report { get; private set; }


        public bool IsAvailableForMedicalReport()
        {
            MedicalExams.ToList().ForEach(x => x.ValidateStatus());

            return MedicalExams.Any(x => x.ExamStatus == ExamStatus.Accomplished);
        }

        public void MakeReport()
        {
            if (IsAvailableForMedicalReport())
            {
                Report = new MedicalReport
                {
                    MedicalConsultationId = this.Id,
                };
            }
            else
            {
                throw new Exception("Laudo não pode ser feito.");
            }
        }

        public void ScheduleExam(Guid medicalEquipamentId, DateTime exameDate)
        {
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
