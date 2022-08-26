using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Department;

namespace Application.DTOs.Course
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public int CourseCode { get; set; }
    }
}
