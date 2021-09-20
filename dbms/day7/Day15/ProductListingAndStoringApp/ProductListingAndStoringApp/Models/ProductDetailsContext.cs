using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ProductListingAndStoringApp.Models
{
    public partial class ProductDetailsContext : DbContext
    {
        public ProductDetailsContext()
        {
        }

        public ProductDetailsContext(DbContextOptions<ProductDetailsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source=KANINI-LTP-476\\SQLSERVER2021ACH;Integrated Security=true;Initial catalog=ProductDetails");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProdId)
                    .HasName("PK__Product__042785E529F74A4D");

                entity.ToTable("Product");

                entity.Property(e => e.ProdId).ValueGeneratedNever();

                entity.Property(e => e.ProdName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Quantity).HasColumnName("quantity");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
