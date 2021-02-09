using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Form.API.Models;

namespace Form.API.Repository
{
    public interface IDepartmentRepository : IDisposable
    {
        Task<IEnumerable<Department>> GetAllDepartmentsAsync();
        Task<Department> GetDepartmentByIdAsync(int departmentId);
        Task<int> AddDepartmentAsync(Department department);
        Task<int> UpdateDepartmentAsync(Department department);
        Task<Department> DeleteDepartmentAsync(int departmentId);
    }
}
