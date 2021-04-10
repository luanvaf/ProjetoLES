using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Core.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.Login)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasIndex(x => x.Login)
                .IsUnique();

            builder.Property(x => x.RoleId)
                .IsRequired();

            builder.HasDiscriminator<string>("UserType")
                .HasValue<Resident>(UserRoleType.Resident.ToString())
                .HasValue<Doctor>(UserRoleType.Doctor.ToString())
                .HasValue<Professor>(UserRoleType.Professor.ToString())
                .HasValue<Administrator>(UserRoleType.Administrator.ToString());

            builder.HasOne(x => x.UserRole)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.RoleId);

        }

    }
}
