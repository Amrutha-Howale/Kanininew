using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CodeFirstApproach.Models
{
    public partial class pubsContext : DbContext
    {
        public pubsContext()
        {
        }

        public pubsContext(DbContextOptions<pubsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<BookDetail> BookDetails { get; set; }
        public virtual DbSet<Cust> Custs { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<EmplSal> EmplSals { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Employeesalary> Employeesalaries { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<PubInfo> PubInfos { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Roysched> Royscheds { get; set; }
        public virtual DbSet<Salary> Salaries { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<TblAnotherEmployee> TblAnotherEmployees { get; set; }
        public virtual DbSet<TblEmpSample> TblEmpSamples { get; set; }
        public virtual DbSet<TblEmpl> TblEmpls { get; set; }
        public virtual DbSet<TblEmpl1> TblEmpls1 { get; set; }
        public virtual DbSet<TblSalary> TblSalaries { get; set; }
        public virtual DbSet<TblTriggercheck> TblTriggerchecks { get; set; }
        public virtual DbSet<Tblanotheremp> Tblanotheremps { get; set; }
        public virtual DbSet<Title> Titles { get; set; }
        public virtual DbSet<Titleauthor> Titleauthors { get; set; }
        public virtual DbSet<Titleview> Titleviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=KANINI-LTP-476\\SQLSERVER2021ACH;Integrated Security=true;Initial catalog=pubs");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(e => e.AuId)
                    .HasName("UPKCL_auidind");

                entity.ToTable("authors");

                entity.HasIndex(e => new { e.AuLname, e.AuFname }, "aunmind");

                entity.Property(e => e.AuId)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("au_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.AuFname)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("au_fname");

                entity.Property(e => e.AuLname)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("au_lname");

                entity.Property(e => e.City)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.Contract).HasColumnName("contract");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("phone")
                    .HasDefaultValueSql("('UNKNOWN')")
                    .IsFixedLength(true);

                entity.Property(e => e.State)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("state")
                    .IsFixedLength(true);

                entity.Property(e => e.Zip)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("zip")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<BookDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("book_details");

                entity.Property(e => e.Author)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("author");

                entity.Property(e => e.Bookname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("bookname");

                entity.Property(e => e.Bookprice)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("bookprice");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Totalprice)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("totalprice");
            });

            modelBuilder.Entity<Cust>(entity =>
            {
                entity.ToTable("cust");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.ReffBy).HasColumnName("reffBy");

                entity.HasOne(d => d.ReffByNavigation)
                    .WithMany(p => p.InverseReffByNavigation)
                    .HasForeignKey(d => d.ReffBy)
                    .HasConstraintName("fk_reff");
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("discounts");

                entity.Property(e => e.Discount1)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("discount");

                entity.Property(e => e.Discounttype)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("discounttype");

                entity.Property(e => e.Highqty).HasColumnName("highqty");

                entity.Property(e => e.Lowqty).HasColumnName("lowqty");

                entity.Property(e => e.StorId)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("stor_id")
                    .IsFixedLength(true);

                entity.HasOne(d => d.Stor)
                    .WithMany()
                    .HasForeignKey(d => d.StorId)
                    .HasConstraintName("FK__discounts__stor___3C69FB99");
            });

            modelBuilder.Entity<EmplSal>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("emplSal");

                entity.Property(e => e.EmpId).HasColumnName("empId");

                entity.Property(e => e.SalDate)
                    .HasColumnType("date")
                    .HasColumnName("salDate");

                entity.Property(e => e.SalId)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("salId");

                entity.Property(e => e.TotalSal).HasColumnName("totalSal");

                entity.HasOne(d => d.Emp)
                    .WithMany()
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK__emplSal__empId__40F9A68C");

                entity.HasOne(d => d.Sal)
                    .WithMany()
                    .HasForeignKey(d => d.SalId)
                    .HasConstraintName("FK__emplSal__salId__41EDCAC5");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK_emp_id")
                    .IsClustered(false);

                entity.ToTable("employee");

                entity.HasIndex(e => new { e.Lname, e.Fname, e.Minit }, "employee_ind")
                    .IsClustered();

                entity.Property(e => e.EmpId)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("emp_id")
                    .IsFixedLength(true);

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("fname");

                entity.Property(e => e.HireDate)
                    .HasColumnType("datetime")
                    .HasColumnName("hire_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.JobId)
                    .HasColumnName("job_id")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.JobLvl)
                    .HasColumnName("job_lvl")
                    .HasDefaultValueSql("((10))");

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("lname");

                entity.Property(e => e.Minit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("minit")
                    .IsFixedLength(true);

                entity.Property(e => e.PubId)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("pub_id")
                    .HasDefaultValueSql("('9952')")
                    .IsFixedLength(true);

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.JobId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__employee__job_id__48CFD27E");

                entity.HasOne(d => d.Pub)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PubId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__employee__pub_id__4BAC3F29");
            });

            modelBuilder.Entity<Employeesalary>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__employee__AFB3EC0DCEE4713F");

                entity.ToTable("employeesalary");

                entity.Property(e => e.EmpId).HasColumnName("empId");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.SalId).HasColumnName("salId");

                entity.Property(e => e.Saldate)
                    .HasColumnType("datetime")
                    .HasColumnName("saldate");

                entity.HasOne(d => d.Sal)
                    .WithMany(p => p.Employeesalaries)
                    .HasForeignKey(d => d.SalId)
                    .HasConstraintName("FK__employees__salId__18EBB532");
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.ToTable("jobs");

                entity.Property(e => e.JobId).HasColumnName("job_id");

                entity.Property(e => e.JobDesc)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("job_desc")
                    .HasDefaultValueSql("('New Position - title not formalized yet')");

                entity.Property(e => e.MaxLvl).HasColumnName("max_lvl");

                entity.Property(e => e.MinLvl).HasColumnName("min_lvl");
            });

            modelBuilder.Entity<PubInfo>(entity =>
            {
                entity.HasKey(e => e.PubId)
                    .HasName("UPKCL_pubinfo");

                entity.ToTable("pub_info");

                entity.Property(e => e.PubId)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("pub_id")
                    .IsFixedLength(true);

                entity.Property(e => e.Logo)
                    .HasColumnType("image")
                    .HasColumnName("logo");

                entity.Property(e => e.PrInfo)
                    .HasColumnType("text")
                    .HasColumnName("pr_info");

                entity.HasOne(d => d.Pub)
                    .WithOne(p => p.PubInfo)
                    .HasForeignKey<PubInfo>(d => d.PubId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__pub_info__pub_id__440B1D61");
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.HasKey(e => e.PubId)
                    .HasName("UPKCL_pubind");

                entity.ToTable("publishers");

                entity.Property(e => e.PubId)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("pub_id")
                    .IsFixedLength(true);

                entity.Property(e => e.City)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("country")
                    .HasDefaultValueSql("('USA')");

                entity.Property(e => e.PubName)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("pub_name");

                entity.Property(e => e.State)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("state")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Roysched>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("roysched");

                entity.HasIndex(e => e.TitleId, "titleidind");

                entity.Property(e => e.Hirange).HasColumnName("hirange");

                entity.Property(e => e.Lorange).HasColumnName("lorange");

                entity.Property(e => e.Royalty).HasColumnName("royalty");

                entity.Property(e => e.TitleId)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("title_id");

                entity.HasOne(d => d.Title)
                    .WithMany()
                    .HasForeignKey(d => d.TitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__roysched__title___3A81B327");
            });

            modelBuilder.Entity<Salary>(entity =>
            {
                entity.HasKey(e => e.SalId)
                    .HasName("PK__Salary__E3E89296912E818B");

                entity.ToTable("Salary");

                entity.Property(e => e.SalId)
                    .ValueGeneratedNever()
                    .HasColumnName("salId");

                entity.Property(e => e.Basic).HasColumnName("basic");

                entity.Property(e => e.Da).HasColumnName("da");

                entity.Property(e => e.Deductions).HasColumnName("deductions");

                entity.Property(e => e.Hra).HasColumnName("hra");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasKey(e => new { e.StorId, e.OrdNum, e.TitleId })
                    .HasName("UPKCL_sales");

                entity.ToTable("sales");

                entity.HasIndex(e => e.TitleId, "titleidind");

                entity.Property(e => e.StorId)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("stor_id")
                    .IsFixedLength(true);

                entity.Property(e => e.OrdNum)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ord_num");

                entity.Property(e => e.TitleId)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("title_id");

                entity.Property(e => e.OrdDate)
                    .HasColumnType("datetime")
                    .HasColumnName("ord_date");

                entity.Property(e => e.Payterms)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("payterms");

                entity.Property(e => e.Qty).HasColumnName("qty");

                entity.HasOne(d => d.Stor)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.StorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__sales__stor_id__37A5467C");

                entity.HasOne(d => d.Title)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.TitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__sales__title_id__38996AB5");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(e => e.StorId)
                    .HasName("UPK_storeid");

                entity.ToTable("stores");

                entity.Property(e => e.StorId)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("stor_id")
                    .IsFixedLength(true);

                entity.Property(e => e.City)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.State)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("state")
                    .IsFixedLength(true);

                entity.Property(e => e.StorAddress)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("stor_address");

                entity.Property(e => e.StorName)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("stor_name");

                entity.Property(e => e.Zip)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("zip")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<TblAnotherEmployee>(entity =>
            {
                entity.HasKey(e => e.AnotherEmpId)
                    .HasName("PK__tblAnoth__91F4CAF1132F9CD5");

                entity.ToTable("tblAnotherEmployee");

                entity.Property(e => e.AnotherEmpId).HasColumnName("another_empID");

                entity.Property(e => e.EmpId).HasColumnName("emp_ID");

                entity.Property(e => e.EmpName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("emp_name");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TblAnotherEmployees)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK__tblAnothe__emp_I__4C6B5938");
            });

            modelBuilder.Entity<TblEmpSample>(entity =>
            {
                entity.ToTable("tblEmpSample");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<TblEmpl>(entity =>
            {
                entity.ToTable("tbl_Empl");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<TblEmpl1>(entity =>
            {
                entity.ToTable("tblEmpl");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<TblSalary>(entity =>
            {
                entity.ToTable("tblSalary");

                entity.Property(e => e.Id)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.Basic).HasColumnName("basic");

                entity.Property(e => e.Deductions).HasColumnName("deductions");

                entity.Property(e => e.Hra).HasColumnName("HRA");
            });

            modelBuilder.Entity<TblTriggercheck>(entity =>
            {
                entity.HasKey(e => e.F1)
                    .HasName("PK__tblTrigg__32139E586BB9A224");

                entity.ToTable("tblTriggercheck");

                entity.Property(e => e.F1).HasColumnName("f1");

                entity.Property(e => e.F2)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("f2");
            });

            modelBuilder.Entity<Tblanotheremp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblanotheremp");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Title>(entity =>
            {
                entity.ToTable("titles");

                entity.HasIndex(e => e.Title1, "titleind");

                entity.Property(e => e.TitleId)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("title_id");

                entity.Property(e => e.Advance)
                    .HasColumnType("money")
                    .HasColumnName("advance");

                entity.Property(e => e.Notes)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("notes");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");

                entity.Property(e => e.PubId)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("pub_id")
                    .IsFixedLength(true);

                entity.Property(e => e.Pubdate)
                    .HasColumnType("datetime")
                    .HasColumnName("pubdate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Royalty).HasColumnName("royalty");

                entity.Property(e => e.Title1)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("type")
                    .HasDefaultValueSql("('UNDECIDED')")
                    .IsFixedLength(true);

                entity.Property(e => e.YtdSales).HasColumnName("ytd_sales");

                entity.HasOne(d => d.Pub)
                    .WithMany(p => p.Titles)
                    .HasForeignKey(d => d.PubId)
                    .HasConstraintName("FK__titles__pub_id__2E1BDC42");
            });

            modelBuilder.Entity<Titleauthor>(entity =>
            {
                entity.HasKey(e => new { e.AuId, e.TitleId })
                    .HasName("UPKCL_taind");

                entity.ToTable("titleauthor");

                entity.HasIndex(e => e.AuId, "auidind");

                entity.HasIndex(e => e.TitleId, "titleidind");

                entity.Property(e => e.AuId)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("au_id");

                entity.Property(e => e.TitleId)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("title_id");

                entity.Property(e => e.AuOrd).HasColumnName("au_ord");

                entity.Property(e => e.Royaltyper).HasColumnName("royaltyper");

                entity.HasOne(d => d.Au)
                    .WithMany(p => p.Titleauthors)
                    .HasForeignKey(d => d.AuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__titleauth__au_id__31EC6D26");

                entity.HasOne(d => d.Title)
                    .WithMany(p => p.Titleauthors)
                    .HasForeignKey(d => d.TitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__titleauth__title__32E0915F");
            });

            modelBuilder.Entity<Titleview>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("titleview");

                entity.Property(e => e.AuLname)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("au_lname");

                entity.Property(e => e.AuOrd).HasColumnName("au_ord");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");

                entity.Property(e => e.PubId)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("pub_id")
                    .IsFixedLength(true);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.Property(e => e.YtdSales).HasColumnName("ytd_sales");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
