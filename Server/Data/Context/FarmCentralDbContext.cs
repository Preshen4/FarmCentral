using FarmCentral.Shared.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FarmCentral.Server.Data.Context
{
    public partial class FarmCentralDBContext : IdentityDbContext
    {
        public FarmCentralDBContext()
        {
        }

        public FarmCentralDBContext(DbContextOptions<FarmCentralDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<Farmer> Farmers { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<ProductType> ProductTypes { get; set; }

        public virtual DbSet<Stock> Stocks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Server=tcp:st10083954.database.windows.net,1433;Initial Catalog=FarmCentral;Persist Security Info=False;User ID=ST10083954;Password=Admin123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04FF1F03B39BC");

                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Farmer>(entity =>
            {
                entity.HasKey(e => e.FarmerId).HasName("PK__Farmer__731B88E8AFCB11CA");

                entity.ToTable("Farmer");

                entity.Property(e => e.FarmerId).HasColumnName("FarmerID");
                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductId).HasName("PK__Product__B40CC6ED5292DD82");

                entity.ToTable("Product");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");
                entity.Property(e => e.FarmerId).HasColumnName("FarmerID");
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
                entity.Property(e => e.ProductTypeId).HasColumnName("ProductTypeID");

                entity.HasOne(d => d.Farmer).WithMany(p => p.Products)
                    .HasForeignKey(d => d.FarmerId)
                    .HasConstraintName("FK__Product__FarmerI__3C69FB99");

                entity.HasOne(d => d.ProductType).WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductTypeId)
                    .HasConstraintName("FK__Product__Product__3D5E1FD2");
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.HasKey(e => e.ProductTypeId).HasName("PK__ProductT__A1312F4E536ADE06");

                entity.ToTable("ProductType");

                entity.Property(e => e.ProductTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("ProductTypeID");
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.HasKey(e => e.StockId).HasName("PK__Stock__2C83A9E2083A046F");

                entity.ToTable("Stock");

                entity.Property(e => e.StockId).HasColumnName("StockID");
                entity.Property(e => e.Date).HasColumnType("date");
                entity.Property(e => e.FarmerId).HasColumnName("FarmerID");
                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Farmer).WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.FarmerId)
                    .HasConstraintName("FK__Stock__FarmerID__412EB0B6");

                entity.HasOne(d => d.Product).WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Stock__ProductID__403A8C7D");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

