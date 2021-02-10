using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Form.API.Models;
using Form.API.Models.Context;

namespace Form.API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;

        public UserRepository(UserContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            IEnumerable<User> users = await _context.Users.Include(u => u.Department).ToListAsync();

            return users;
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            User user = await _context.Users
                .Include(u => u.Department)
                .SingleOrDefaultAsync(u => u.Id == userId);

            return user;
        }

        public async Task<int> AddUserAsync(User user)
        {
            int entries = 0;            

            if (user != null)
            {
                await _context.Users.AddAsync(user);
                entries = await _context.SaveChangesAsync();
            }

            return entries;
        }

        public async Task<int> UpdateUserAsync(User user)
        {
            int entries = 0;

            if (user != null)
            {
                _context.Entry(user).State = EntityState.Modified;
                entries = await _context.SaveChangesAsync();
            }

            return entries;
        }

        public async Task<User> DeleteUserAsync(int userId)
        {
            User user = await _context.FindAsync<User>(userId);

            if (user != null)
            {
                _context.Entry(user).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }

            return user;
        }

        public async Task<Department> GetDepartmentByIdAsync(int departmentId)
        {
            Department department = await _context.Departments.FindAsync(departmentId);                

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
