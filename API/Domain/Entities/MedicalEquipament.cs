using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class MedicalEquipament : Entity<Guid>
    {
        public string Name { get; set; }
        public DateTime AcquisitionDate { get; set; }
        public virtual IEnumerable<MedicalExam> MedicalExams { get; set; }
    }
}
