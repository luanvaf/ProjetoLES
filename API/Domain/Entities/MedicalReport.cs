using System;

namespace Domain.Entities
{
    public class MedicalReport : Entity<Guid>
    {
        public Guid MedicalConsultationId { get; set; }
        public string Report { get; set; }
        public DateTime ReportDate { get; set; }
        public Guid ReportCreatorId { get; set; }
        public virtual MedicalConsultation MedicalConsultation { get; set; }
        public virtual Doctor ReportCreator { get; set; }
    }
}
