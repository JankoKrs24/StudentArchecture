using Application.DTOs.Department;
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
    public class DepartmentService:IDepartmentService
    {
        private readonly SchoolContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentService()
        {
            _context = new SchoolContext();
            _unitOfWork = new UnitOfWork(_context);
        }

        public async Task<List<DepartmentDto>> GetAll()
        {
            return await _context.Departments.Select(x => new DepartmentDto
            {
                Id = x.Id,
                DepartmentName = x.DepartmentName
            }).ToListAsync();
        }

        public async Task<DepartmentDto> GetById(int id)
        {
            return await _context.Departments.Select(x => new DepartmentDto
            {
                Id = x.Id,
                DepartmentName = x.DepartmentName
            }).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddDepartment(AddDepartmentDto dto)
        {
            Department department = new Department();

            department.DepartmentName = dto.DepartmentName;

            await _unitOfWork.DepartmentRepository.Create(department);
            await _unitOfWork.Save();
        }

        public async Task UpdateDepartment(EditDepartmentDto dto)
        {
            Department department = await _context.Departments.FindAsync(dto.Id);

            department.DepartmentName = dto.DepartmentName;

            _unitOfWork.DepartmentRepository.Update(department);
            await _unitOfWork.Save();
        }

        public async Task DeleteDepartment(int id)
        {
            await _unitOfWork.DepartmentRepository.Delete(id);
            await _unitOfWork.Save();
        }
    }
}
