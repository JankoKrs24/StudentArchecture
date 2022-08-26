using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Teacher:Person
    {
        public Teacher()
        {
            CourseTeachers = new HashSet<CourseTeacher>();
        }

        public virtual ICollection<CourseTeacher> CourseTeachers { get; set; }
        
    }
}
