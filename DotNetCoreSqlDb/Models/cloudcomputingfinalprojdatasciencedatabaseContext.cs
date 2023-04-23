using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DotNetCoreSqlDb.Models
{
    public partial class cloudcomputingfinalprojdatasciencedatabaseContext : DbContext
    {
        public cloudcomputingfinalprojdatasciencedatabaseContext()
        {
        }

        public cloudcomputingfinalprojdatasciencedatabaseContext(DbContextOptions<cloudcomputingfinalprojdatasciencedatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Household> Households { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=cloudcomputingfinalprojdatascience-server.database.windows.net,1433;Initial Catalog=cloudcomputingfinalprojdatascience-database;User ID=cloudcomputingfinalprojdatascience-server-admin;Password=4BJN2SH4T2FOB12Q$");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Household>(entity =>
            {
                entity.HasKey(e => e.HshdNum);

                entity.Property(e => e.HshdNum)
                    .ValueGeneratedNever()
                    .HasColumnName("HSHD_NUM");

                entity.Property(e => e.AgeRange)
                    .HasMaxLength(250)
                    .HasColumnName("AGE_RANGE");

                entity.Property(e => e.Children)
                    .HasMaxLength(50)
                    .HasColumnName("CHILDREN");

                entity.Property(e => e.HhSize)
                    .HasMaxLength(250)
                    .HasColumnName("HH_SIZE");

                entity.Property(e => e.Homeowner)
                    .HasMaxLength(50)
                    .HasColumnName("HOMEOWNER");

                entity.Property(e => e.HshdComposition)
                    .HasMaxLength(50)
                    .HasColumnName("HSHD_COMPOSITION");

                entity.Property(e => e.IncomeRange)
                    .HasMaxLength(250)
                    .HasColumnName("INCOME_RANGE");

                entity.Property(e => e.L)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.Marital)
                    .HasMaxLength(50)
                    .HasColumnName("MARITAL");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductNum);

                entity.Property(e => e.ProductNum)
                    .ValueGeneratedNever()
                    .HasColumnName("PRODUCT_NUM");

                entity.Property(e => e.BrandTy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("BRAND_TY");

                entity.Property(e => e.Commodity)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("COMMODITY");

                entity.Property(e => e.Department)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("DEPARTMENT");

                entity.Property(e => e.NaturalOrganicFlag)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("NATURAL_ORGANIC_FLAG");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.BasketNum).HasColumnName("BASKET_NUM");

                entity.Property(e => e.HshdNum).HasColumnName("HSHD_NUM");

                entity.Property(e => e.ProductNum).HasColumnName("PRODUCT_NUM");

                entity.Property(e => e.Purchase)
                    .HasColumnType("date")
                    .HasColumnName("PURCHASE");

                entity.Property(e => e.Spend).HasColumnName("SPEND");

                entity.Property(e => e.StoreR)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("STORE_R");

                entity.Property(e => e.Units).HasColumnName("UNITS");

                entity.Property(e => e.WeekNum).HasColumnName("WEEK_NUM");

                entity.Property(e => e.Year).HasColumnName("YEAR");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
