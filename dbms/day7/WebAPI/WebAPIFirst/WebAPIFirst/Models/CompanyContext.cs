using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIFirst.Models
{
    public class CompanyContext:DbContext
    {
       public CompanyContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<User> users { get; set; }
        public DbSet<Flower> flowers { get; set; }
    }
}
