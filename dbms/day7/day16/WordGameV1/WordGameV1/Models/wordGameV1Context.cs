using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WordGameV1.Models
{
    public partial class wordGameV1Context : DbContext
    {
        public wordGameV1Context()
        {
        }

        public wordGameV1Context(DbContextOptions<wordGameV1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserScoreBoard> UserScoreBoards { get; set; }
        public virtual DbSet<UsersWord> UsersWords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=KANINI-LTP-476\\SQLSERVER2021ACH;Integrated Security=true;Initial catalog=wordGameV1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Phone)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserScoreBoard>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserScor__1788CC4CF1E6F30E");

                entity.ToTable("UserScoreBoard");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.HasOne(d => d.User)
                    .WithOne(p => p.UserScoreBoard)
                    .HasForeignKey<UserScoreBoard>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserScore__UserI__3B75D760");
            });

            modelBuilder.Entity<UsersWord>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.Words })
                    .HasName("PK__UsersWor__C692C647E037A790");

                entity.Property(e => e.Words)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersWords)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UsersWord__UserI__38996AB5");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
