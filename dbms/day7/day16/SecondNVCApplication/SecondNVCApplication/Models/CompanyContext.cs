using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondNVCApplication.Models
{
    public class CompanyContext : DbContext
    {
        public CompanyContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Department> departments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                new Department() { Id = 101, Name = "Admin" }
                );
            modelBuilder.Entity<Employee>().HasData(
                new Employee() { Id = 1, Name = "Tim", Age = 21, DepartmentId = 101 },
                new Employee() { Id = 2, Name = "jim", Age = 31, DepartmentId = 101 }
                );
        }
    }
}
