using Application.DTOs.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IStudentService
    {
        Task<List<StudentDto>> GetAll();
        Task<StudentDto> GetById(int id);
        Task AddStudent(AddStudentDto dto);
    }
}
