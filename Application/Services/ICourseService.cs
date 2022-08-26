using Application.DTOs.Course;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface ICourseService
    {
        Task<List<CourseDto>> GetAll();
        Task AddCourse(AddCourseDto dto);
        Task<CourseDto> GetById(int id);
        Task UpdateCourse(EditCourseDto dto);
        Task DeleteCourse(int id);
    }
}
