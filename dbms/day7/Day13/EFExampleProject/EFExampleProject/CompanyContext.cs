using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFExampleProject
{
    public class CompanyContext:DbContext
    {
       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=KANINI-LTP-476\SQLSERVER2021ACH;Integrated Security=true;Initial catalog=dbCompanyEFCF");
        }
        public DbSet<Employee> employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(new Employee()
            {
                Id = 101,
                Name = "jack",
                Age = 23
            });
        }
    }
}
