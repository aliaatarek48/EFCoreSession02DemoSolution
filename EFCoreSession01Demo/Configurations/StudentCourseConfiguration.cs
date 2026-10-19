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
    internal class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            //builder.HasMany(S => S.Courses)
            //		   .WithMany(C => C.Students)
            //		   .UsingEntity(RT =>
            //		   {
            //			   RT.ToTable("Hamda");
            //			   RT.Property<int>("Grade");
            //		   });

            builder.HasKey(SC => new { SC.StdId, SC.CrsId });
        }
    }
}
