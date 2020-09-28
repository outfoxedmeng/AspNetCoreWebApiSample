using ApiSample.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSample.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(build =>
            {
                build.HasKey(c => c.Id);
                build.Property(c => c.Name)
                .HasMaxLength(200)
                .IsRequired();

                build.HasMany(c => c.Employees)
                .WithOne(e => e.Company);
            });


            modelBuilder.Entity<Employee>(build =>
            {
                build.HasKey(e => e.Id);
                build.Property(e => e.Name)
                .HasMaxLength(100)
                .IsRequired();

                build.HasOne(e => e.Company).WithMany(c => c.Employees);

            });
            modelBuilder.Entity<Company>().HasData(
               new Company
               {
                   Id = 1,
                   Name = "Company1",
               },
               new Company
               {
                   Id = 2,
                   Name = "Company2",
               }
               );

            modelBuilder.Entity<Employee>().HasData(
                 new Employee
                 {
                     Id = 1,
                     Name = "Employee1-1",
                     Gender = Gender.Female,
                     CompanyId = 1
                 },
                 new Employee
                 {
                     Id = 2,
                     Name = "Employee1-2",
                     Gender = Gender.Male,
                     CompanyId = 1
                 },
                  new Employee
                  {
                      Id = 3,
                      Name = "Employee2-1",
                      Gender = Gender.Female,
                      CompanyId = 2
                  },
                 new Employee
                 {
                     Id = 4,
                     Name = "Employee2-2",
                     Gender = Gender.Male,
                     CompanyId = 2
                 }
                );
        }


        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
