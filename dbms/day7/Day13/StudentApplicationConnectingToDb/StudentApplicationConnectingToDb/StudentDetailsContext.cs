using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentApplicationConnectingToDb
{
    public class StudentDetailsContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=KANINI-LTP-476\SQLSERVER2021ACH;Integrated Security=true;Initial catalog=Day13Questions1");
        }
        public DbSet<Student> students { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //first three values are added during migration
            modelBuilder.Entity<Student>().HasData(new Student()
            {
                Id = 101,
                Name = "jack",
                DateofJoining = Convert.ToDateTime("13/08/21")
            });
            modelBuilder.Entity<Student>().HasData(new Student()
            {
                Id = 102,
                Name = "jill",
                DateofJoining = Convert.ToDateTime("12/08/21")
            });
            modelBuilder.Entity<Student>().HasData(new Student()
            {
                Id = 103,
                Name = "james",
                DateofJoining = Convert.ToDateTime("20/08/21")
            });
        }
    }
}
