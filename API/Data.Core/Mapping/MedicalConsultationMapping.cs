using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Core.Mapping
{
    public class MedicalConsultationMapping : IEntityTypeConfiguration<MedicalConsultation>
    {
        public void Configure(EntityTypeBuilder<MedicalConsultation> builder)
        {
            builder.ToTable(nameof(MedicalConsultation));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.DoctorId).IsRequired();
            builder.Property(x => x.PatientId).IsRequired();
            builder.Property(x => x.CreatedAt).IsRequired();

            builder.Property(x => x.ConsultationDate).IsRequired();


            builder.HasOne(x => x.Doctor)
                .WithMany(x => x.MedicalConsultations)
                .HasForeignKey(x => x.DoctorId);

            builder.HasOne(x => x.Patient)
                .WithMany(x => x.MedicalConsultations)
                .HasForeignKey(x => x.PatientId);

            builder.HasOne(x => x.Report)
                .WithOne(x => x.MedicalConsultation)
                .HasForeignKey<MedicalReport>(x => x.MedicalConsultationId);

            builder.HasMany(x => x.MedicalExams)
                .WithOne(x => x.MedicalConsultation)
                .HasForeignKey(x => x.MedicalConsultationId);

        }
    }
}
