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
    public class StudentCourseConfiguration : BaseConfiguration<StudentCourse>, IEntityTypeConfiguration<StudentCourse>
    {
        public override void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            base.Configure(builder);

            builder.HasOne(d => d.Student)
                    .WithMany(p => p.StudentCourses)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
