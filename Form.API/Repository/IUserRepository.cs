using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Form.API.Models;

namespace Form.API.Repository
{
    public interface IUserRepository : IDisposable
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int userId);
        Task<int> AddUserAsync(User user);
        Task<int> UpdateUserAsync(User user);
        Task<User> DeleteUserAsync(int userId);

        Task<Department> GetDepartmentByIdAsync(int departmentId);
    }
}
