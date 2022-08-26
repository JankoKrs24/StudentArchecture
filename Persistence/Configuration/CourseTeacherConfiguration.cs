using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configuration
{
    public class CourseTeacherConfiguration : BaseConfiguration<CourseTeacher>, IEntityTypeConfiguration<CourseTeacher>
    {
        public override void Configure(EntityTypeBuilder<CourseTeacher> builder)
        {
            base.Configure(builder);


            builder.HasOne(d => d.Course)
                    .WithMany(p => p.CourseTeachers)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.Teacher)
                    .WithMany(p => p.CourseTeachers)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
