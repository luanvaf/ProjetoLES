using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Core.Mapping
{
    public class MedicalReportMapping : IEntityTypeConfiguration<MedicalReport>
    {
        public void Configure(EntityTypeBuilder<MedicalReport> builder)
        {
            builder.ToTable(nameof(MedicalReport));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.MedicalConsultationId).IsRequired();

            builder.Property(x => x.Report).IsRequired().HasMaxLength(500);

            builder.Property(x => x.CreatedAt).IsRequired();

            builder.HasOne(x => x.MedicalConsultation)
                .WithOne(x => x.Report)
                .HasForeignKey<MedicalReport>(x => x.MedicalConsultationId);
        }
    }
}
