using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginMVC.Models
{
    public class UserContext:DbContext
    {
        public UserContext()
        {
        }

        public UserContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User() {  Id = 101, Password="tim" },
                new User() {  Id = 102, Password="jim"}
                );
        }
    }
}
