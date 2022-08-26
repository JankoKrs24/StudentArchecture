using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Course : BaseEntity
    {
        public Course()
        {

            CourseTeachers = new HashSet<CourseTeacher>();
            StudentCourses = new HashSet<StudentCourse>();
        }
        public int? DepartmentId { get; set; }
        public string? CourseName { get; set; }
        public int CourseCode { get; set; }

        public virtual Department Department { get; set; } = null!;
        public virtual ICollection<CourseTeacher> CourseTeachers { get; set; }
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
        
    }
}
