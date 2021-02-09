using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Form.API.Models;

namespace Form.API.Models.Context
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> opts) : base(opts) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
