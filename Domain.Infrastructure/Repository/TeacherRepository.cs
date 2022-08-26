using Domain.Interfaces;
using Domain.Models;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Infrastructure.Repository
{
    public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(SchoolContext context) : base(context)
        {
        }

        public void RegisterTeacherToCourse(Teacher teacher, Course course)
        {
            CourseTeacher ct = new CourseTeacher();
            ct.TeacherId = teacher.Id;
            ct.CourseId = course.Id;
            ct.Created=DateTime.Now;

            _context.Add(ct);
        }
    }
}
