using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using AttendanceSystemWebAPI.Models;

namespace AttendanceSystemWebAPI.DAL
{
    public class mysqlContextDAL : IdentityDbContext<ApplicationUserModel>
    {
        public mysqlContextDAL(DbContextOptions<mysqlContextDAL> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public virtual DbSet<EmployeesModel> Employees { get; set; }
    }
}
