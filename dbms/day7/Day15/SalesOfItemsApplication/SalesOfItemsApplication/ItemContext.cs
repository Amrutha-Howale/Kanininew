using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesOfItemsApplication
{
    public class ItemContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=KANINI-LTP-476\SQLSERVER2021ACH;Integrated Security=true;Initial catalog=SalesItemDB");
        }
        public DbSet<Item> items { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasData(new Item()
            {
                ItemId = 101,
                ProductName = "XXX",
                ProductPrice = 12,
                Quantity = 3
            });
            modelBuilder.Entity<Item>().HasData(new Item()
            {
                ItemId = 102,
                ProductName = "YYY",
                ProductPrice = 15,
                Quantity = 0
            });
            modelBuilder.Entity<Item>().HasData(new Item()
            {
                ItemId = 103,
                ProductName = "ZZZ",
                ProductPrice = 20,
                Quantity = 2
            });
        }
    }
}
