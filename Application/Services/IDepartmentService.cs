using Application.DTOs.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IDepartmentService
    {
        Task<List<DepartmentDto>> GetAll();
        Task<DepartmentDto> GetById(int id);
        Task AddDepartment(AddDepartmentDto dto);
        Task UpdateDepartment(EditDepartmentDto dto);
        Task DeleteDepartment(int id);
    }
}
