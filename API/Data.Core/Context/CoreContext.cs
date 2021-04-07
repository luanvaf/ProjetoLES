using Domain.Entities;
using Domain.Interfaces.Util;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace Data.Core.Context
{
    public sealed class CoreContext: DbContext
    {
        private readonly ICryptograph _cryptograph;
        public DbSet<User> Users{ get; private set; }
        public DbSet<Address> Address { get; private set; }
        public DbSet<Administrator> Administrator { get; private set; }
        public DbSet<Doctor> Doctor { get; private set; }
        public DbSet<Patient> Patient { get; private set; }
        public DbSet<Professor> Professor { get; private set; }
        public DbSet<Resident> Resident { get; private set; }
        
        public CoreContext(DbContextOptions<CoreContext> options, ICryptograph cryptograph) : base(options) 
        {
            _cryptograph = cryptograph;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<UserRole>().HasData(
                Enum.GetValues(typeof(UserRoleType))
                    .Cast<UserRoleType>()
                    .Select(x => new UserRole()
                    {
                        Id = x,
                        Name = x.ToString(),
                    }));

            modelBuilder.Entity<Administrator>().HasData(new Administrator
            {
                Id = Guid.Parse("319e2862-5c31-477a-9eeb-d84db67b2fc5"),
                Crm = "999999",
                Name = "administrador",
                CreatedAt = DateTime.Now,
                Password = _cryptograph.EncryptPassword("abc123")
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
