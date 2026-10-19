using EFCoreSession02Demo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreSession02Demo.Configurations
{
    internal class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> D)
        {
            D.ToTable("Departments", "Sales");
            D.HasKey(D => D.DeptId);
            D.Property(D => D.DeptId).UseIdentityColumn(10, 10);

            D.Property(D => D.DeptName)
              .HasColumnName("DepartmentName")
              .HasColumnType("varchar")
              .HasMaxLength(50)
              .IsRequired(false)
              .HasDefaultValue("HR");

            D.Property(D => D.DateOfCreation)
            .HasDefaultValueSql("GETDATE()"); // Get Current DateTime When Row | Record Inserted
                                              //.HasComputedColumnSql("GetDate()"); // Calculated By SQL Server Every Time You Query DateOfCreation
                                              //.HasDefaultValue(DateTime.Now); // Use DateTime.Now -> Time Migration 

            D.Ignore(D => D.Serial); // Not Mapped 

            D.Property<DateTime>("CreatedAt").HasDefaultValueSql("GETDATE()"); // Shadow Property


            #region Manage Relationship
            D.HasOne(E => E.Manager)
                        .WithOne(D => D.ManagedDepartment)
                        .HasForeignKey<Department>(D => D.DeptManagerId)
                        .OnDelete(DeleteBehavior.Restrict);
            #endregion
        }
    }
}