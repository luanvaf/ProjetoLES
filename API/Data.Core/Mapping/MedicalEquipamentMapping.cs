using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Core.Mapping
{
    public class MedicalEquipamentMapping : IEntityTypeConfiguration<MedicalEquipament>
    {
        public void Configure(EntityTypeBuilder<MedicalEquipament> builder)
        {
            builder.ToTable(nameof(MedicalEquipament));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.AcquisitionDate).IsRequired();

            builder.HasMany(x => x.MedicalExams)
                .WithOne(x => x.MedicalEquipament)
                .HasForeignKey(x => x.MedicalEquipamentId);
        }
    }
}
