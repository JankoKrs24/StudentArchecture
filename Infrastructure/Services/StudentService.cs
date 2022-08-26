using Application.DTOs.Student;
using Application.Services;
using Domain.Infrastructure;
using Domain.Models;
using Domain.Service;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class StudentService:IStudentService
    {
        private readonly SchoolContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public StudentService()
        {
            _context = new SchoolContext();
            _unitOfWork = new UnitOfWork(_context);
        }

        public async Task<List<StudentDto>> GetAll()
        {
            return await _context.Students.Select(x => new StudentDto
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName
            }).ToListAsync();
        }

        public async Task<StudentDto> GetById(int id)
        {
            return await _context.Students.Select(x=>new StudentDto
            {
                Id=x.Id,
                FirstName = x.FirstName,
                LastName=x.LastName
            }).FirstOrDefaultAsync(x=>x.Id== id);
        }

        public async Task AddStudent(AddStudentDto dto)
        {
            Student student = new Student();

            student.FirstName = dto.FirstName;
            student.LastName = dto.LastName;
            student.Address = Address.CreateInstance(dto.Address.Country, dto.Address.City, dto.Address.ZipCode, dto.Address.Street);

            await _unitOfWork.StudentRepository.Create(student);
            await _unitOfWork.Save();
        }

        public async Task UpdateStudent(EditStudentFullNameDto dto)
        {
            Student student = await _context.Students.FindAsync(dto.Id);

            student.FirstName = dto.FirstName;
            student.LastName = dto.LastName;

            _unitOfWork.StudentRepository.Update(student);
            await _unitOfWork.Save();
        }

        public async Task DeleteStudent(int id)
        {
            await _unitOfWork.StudentRepository.Delete(id);
            await _unitOfWork.Save();
        }
    }
}
