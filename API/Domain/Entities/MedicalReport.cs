using System;

namespace Domain.Entities
{
    public class MedicalReport : Entity<Guid>
    {
        public Guid MedicalConsultationId { get; set; }
        public string Report { get; set; }
        public virtual MedicalConsultation MedicalConsultation { get; set; }
    }
}
