using Domain.ValueObjects;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Doctor : User
    {
        public Doctor()
        {
            this.RoleId = UserRoleType.Doctor;
        }

        /// <summary>
        /// Crm
        /// </summary>
        public string Crm { get; set; }
        public virtual IEnumerable<MedicalConsultation> MedicalConsultations { get; set; }
        public virtual IEnumerable<MedicalExam> MedicalExams { get; set; }
    }
}
