using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Department:BaseEntity
    {
        public Department()
        {
            Courses = new HashSet<Course>();
        }
        public string DepartmentName { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
