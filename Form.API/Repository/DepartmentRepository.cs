using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Form.API.Models.Context;
using Form.API.Models;

namespace Form.API.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly UserContext _context;

        public DepartmentRepository(UserContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {            
            IEnumerable<Department> departments = await _context.Departments.Include(d => d.Users).ToListAsync();
            
            return departments;
        }

        public async Task<Department> GetDepartmentByIdAsync(int departmentId)
        {
            // Self referencing loop
            Department department = await _context.Departments
                .Include(d => d.Users)
                .SingleOrDefaultAsync(d => d.Id == departmentId);
            
            return department;
        }

        public async Task<int> AddDepartmentAsync(Department department)
        {
            int entries = 0;

            if (department != null)
            {
                await _context.Departments.AddAsync(department);
                entries = await _context.SaveChangesAsync();
            }

            return entries;
        }

        public async Task<int> UpdateDepartmentAsync(Department department)
        {
            int entries = 0;

            if (department != null)
            {
                _context.Entry(department).State = EntityState.Modified;
                entries = await _context.SaveChangesAsync();
            }

            return entries;
        }

        public async Task<Department> DeleteDepartmentAsync(int departmentId)
        {
            Department department = await _context.FindAsync<Department>(departmentId);

            if (department != null)
            {
                _context.Entry(department).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }

            return department;
        }

        private bool disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}