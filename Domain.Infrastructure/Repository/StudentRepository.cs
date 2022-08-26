using Domain.Interfaces;
using Domain.Models;
using Microsoft.VisualBasic;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Infrastructure.Repository
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(SchoolContext context) : base(context)
        {
        }

        public void RegisterStudentToCourse(Student student, Course course)
        {
            StudentCourse sc = new StudentCourse();
            sc.StudentId = student.Id;
            sc.CourseId = course.Id;
            sc.Grade = 8;
            sc.Created = DateTime.Now;

            _context.StudentCourses.Add(sc);
        }
    }
}
