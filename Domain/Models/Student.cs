using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Student:Person
    {
        public Student()
        {
            StudentCourses = new HashSet<StudentCourse>();
        }

        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
