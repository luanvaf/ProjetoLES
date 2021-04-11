using Domain.Entities;
using System;

namespace Service.Adapter
{
    public class MedicalConsultationAdapter
    {
        public static MedicalConsultation CreateMedicalConsultation(Guid patientId, Guid doctorId)
            => new MedicalConsultation
            {
                PatientId = patientId,
                DoctorId = doctorId,
                ConsultationDate = DateTime.Now
            };
    }
}
