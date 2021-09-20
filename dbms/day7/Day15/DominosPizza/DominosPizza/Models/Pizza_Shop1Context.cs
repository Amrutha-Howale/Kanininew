using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DominosPizza.Models
{
    public partial class Pizza_Shop1Context : DbContext
    {
        public Pizza_Shop1Context()
        {
        }

        public Pizza_Shop1Context(DbContextOptions<Pizza_Shop1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Pizza> Pizzas { get; set; }
        public virtual DbSet<Topping> Toppings { get; set; }
        public virtual DbSet<ToppingDetail> ToppingDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=KANINI-LTP-476\\SQLSERVER2021ACH;Integrated Security=true;Initial catalog=Pizza_Shop1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustId)
                    .HasName("pk_customers");

                entity.Property(e => e.CustId).HasColumnName("Cust_ID");

                entity.Property(e => e.CustAddress)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("Cust_Address");

                entity.Property(e => e.CustEmail)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Cust_Email");

                entity.Property(e => e.CustName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Cust_Name");

                entity.Property(e => e.CustPassword)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Cust_Password");

                entity.Property(e => e.CustPhone)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("Cust_Phone")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("Order_ID");

                entity.Property(e => e.CustId).HasColumnName("Cust_ID");

                entity.Property(e => e.DeliveryAddress)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("Delivery_Address");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Order_date");

                entity.Property(e => e.TotalPrice).HasColumnName("Total_Price");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustId)
                    .HasConstraintName("FK__Orders__Cust_ID__3C69FB99");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("Order_Details");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.OrderId).HasColumnName("Order_ID");

                entity.Property(e => e.PizzaId).HasColumnName("Pizza_ID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order_Det__Order__403A8C7D");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.PizzaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order_Det__Pizza__3F466844");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.ToTable("Pizza");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PizzaName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Pizza_Name");

                entity.Property(e => e.PizzaType)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Pizza_Type");

                entity.Property(e => e.Price).HasColumnName("price");
            });

            modelBuilder.Entity<Topping>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ToppingsName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Toppings_Name");
            });

            modelBuilder.Entity<ToppingDetail>(entity =>
            {
                entity.HasKey(e => e.ToppingDetailsId)
                    .HasName("PK__Topping___218B505F3F7EB39D");

                entity.ToTable("Topping_Details");

                entity.Property(e => e.ToppingDetailsId).HasColumnName("Topping_Details_id");

                entity.Property(e => e.DetailsId).HasColumnName("Details_ID");

                entity.Property(e => e.ToppingsId).HasColumnName("Toppings_ID");

                entity.HasOne(d => d.Details)
                    .WithMany(p => p.ToppingDetails)
                    .HasForeignKey(d => d.DetailsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Topping_D__Detai__4316F928");

                entity.HasOne(d => d.Toppings)
                    .WithMany(p => p.ToppingDetails)
                    .HasForeignKey(d => d.ToppingsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Topping_D__Toppi__440B1D61");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
