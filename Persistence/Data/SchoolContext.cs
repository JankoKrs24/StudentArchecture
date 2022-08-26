using Domain.Models;
using Domain.Models.Base;
using Microsoft.EntityFrameworkCore;
using Persistence.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Data
{
    public class SchoolContext : DbContext
    {
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<CourseTeacher> CourseTeachers { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<StudentCourse> StudentCourses { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=SchoolDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BaseConfiguration<>).Assembly);
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfiguration(new CourseConfiguration());
        //    modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
        //    modelBuilder.ApplyConfiguration(new TeacherConfiguration());
        //    modelBuilder.ApplyConfiguration(new CourseTeacherConfiguration());
        //    modelBuilder.ApplyConfiguration(new StudentConfiguration());
        //    modelBuilder.ApplyConfiguration(new StudentCourseConfiguration());
        //}
    }
}
