using Application.DTOs.Course;
using Application.Services;
using Domain.Infrastructure;
using Domain.Infrastructure.Repository;
using Domain.Models;
using Domain.Service;
using Domain.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class CourseService:ICourseService
    {
        private readonly SchoolContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public CourseService()
        {
            _context = new SchoolContext();
            _unitOfWork = new UnitOfWork(_context);
        }

        public async Task<List<CourseDto>> GetAll()
        {
            List<CourseDto> courseDtos = await _context.Courses.Select(x => new CourseDto
            {
                Id = x.Id,
                CourseName = x.CourseName,
                CourseCode = x.CourseCode,
            }).ToListAsync();

            
            return courseDtos;
        }

        public async Task<CourseDto> GetById(int id)
        {
            return await _context.Courses.Select(x => new CourseDto
            {
                Id = x.Id,
                CourseName = x.CourseName,
                CourseCode = x.CourseCode
            }).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddCourse(AddCourseDto dto)
        {
            Course course = new Course();

            course.CourseName = dto.CourseName;
            course.CourseCode = dto.CourseCode;

            await _unitOfWork.CourseRepository.Create(course);
            await _unitOfWork.Save();
        }

        public async Task UpdateCourse(EditCourseDto dto)
        {
            Course course = await _context.Courses.FindAsync(dto.Id);

            course.DepartmentId = dto.DepartmentId;
            course.CourseName = dto.CourseName;
            course.CourseCode = dto.CourseCode;

            _unitOfWork.CourseRepository.Update(course);
            await _unitOfWork.Save();
        }

        public async Task DeleteCourse(int id)
        {
            await _unitOfWork.CourseRepository.Delete(id);
            await _unitOfWork.Save();

        }
    }
}
