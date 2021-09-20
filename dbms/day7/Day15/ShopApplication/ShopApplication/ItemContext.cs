using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApplication
{
    public class ItemContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=KANINI-LTP-476\SQLSERVER2021ACH;Integrated Security=true;Initial catalog=ItemProductDB");
        }
        public DbSet<ItemsList> itemsLists { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemsList>().HasData(new ItemsList()
            {
                ItemId=101,
                ProductNumber=1,
                ProductName= "XXX",
                ProductPrice=12,
                Quantity=3
            });
            modelBuilder.Entity<ItemsList>().HasData(new ItemsList()
            {
                ItemId = 102,
                ProductNumber = 2,
                ProductName = "YYY",
                ProductPrice = 15,
                Quantity = 0
            });
            modelBuilder.Entity<ItemsList>().HasData(new ItemsList()
            {
                ItemId = 103,
                ProductNumber = 3,
                ProductName = "ZZZ",
                ProductPrice = 20,
                Quantity = 2
            });
        }
    }
}
