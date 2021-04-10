using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Core.Mapping
{
    public class MedicalExamMapping : IEntityTypeConfiguration<MedicalExam>
    {
        public void Configure(EntityTypeBuilder<MedicalExam> builder)
        {
            builder.ToTable(nameof(MedicalExam));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();

            builder.Property(x => x.MedicalConsultationId).IsRequired();
            builder.Property(x => x.MedicalEquipamentId);
            builder.Property(x => x.DoctorPerfomedExamId);
            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.ExamStatus).IsRequired();
            builder.Property(x => x.ExamDate).IsRequired();
            builder.Property(x => x.ExamResult).HasMaxLength(500);


            builder.HasOne(x => x.MedicalConsultation)
                .WithMany(x => x.MedicalExams)
                .HasForeignKey(x => x.MedicalConsultationId);

            builder.HasOne(x => x.MedicalEquipament)
                .WithMany(x => x.MedicalExams)
                .HasForeignKey(x => x.MedicalEquipamentId);

            builder.HasOne(x => x.DoctorPerfomedExam)
                .WithMany(x => x.MedicalExams)
                .HasForeignKey(x => x.DoctorPerfomedExamId);
        }
    }
}
