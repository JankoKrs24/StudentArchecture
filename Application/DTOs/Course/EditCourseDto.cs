using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Course
{
    public class EditCourseDto
    {
        public int Id { get; set; }
        public int? DepartmentId { get; set; }
        public string CourseName { get; set; }
        public int CourseCode { get; set; }
    }
}
