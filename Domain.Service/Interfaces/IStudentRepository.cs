//using Domain.Models;
using Domain.Models;
using Domain.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IStudentRepository: IBaseRepository<Student>
    {
        void RegisterStudentToCourse(Student student, Course course);
    }
}
