using EFCoreSession02Demo.Configurations;
using EFCoreSession02Demo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreSession02Demo
{
    internal class CompanyDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = .; Database = CompanyDb; Trusted_Connection = true; TrustServerCertificate =true");
        }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Employee With Fluent API
            //modelBuilder.Entity<Employee>().ToTable("EmployeesTable");
            //modelBuilder.Entity<Employee>().HasKey(E => E.EmpId);

            //modelBuilder.Entity<Employee>().Property(E => E.EmpId).UseIdentityColumn(10, 10); // EF Core 5

            //modelBuilder.Entity<Employee>().Property(E => E.EmpName)
            //    .HasColumnName("EmployeeName")
            //    .HasColumnType("varchar")
            //    .HasMaxLength(50); // EmployeeName Varchar(50)

            //modelBuilder.Entity<Employee>().Property(E => E.Salary).HasPrecision(10, 2);

            //modelBuilder.Entity<Employee>().ToTable(T => T.HasCheckConstraint("Check_Employee_Age_Range", "[Age] Between 22 And 40"));

            //modelBuilder.Entity<Employee>().Property(E => E.Email).IsRequired();

            //modelBuilder.Entity<Employee>().ToTable(T => T.HasCheckConstraint("Check_Employee_Email", "[Email] Like '%@%.%'"));

            //modelBuilder.Entity<Employee>().Ignore(E => E.UserName);
            #endregion

            modelBuilder.ApplyConfiguration<Department>(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration<Employee>(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration<EmployeeProject>(new EmployeeProjectConfiguration());
            modelBuilder.ApplyConfiguration<StudentCourse>(new StudentCourseConfiguration());
        }
    }
}
