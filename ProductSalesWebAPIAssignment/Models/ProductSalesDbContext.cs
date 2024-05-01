using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProductSalesWebAPIAssignment.Models;

public partial class ProductSalesDbContext : DbContext
{
    public ProductSalesDbContext()
    {
    }

    public ProductSalesDbContext(DbContextOptions<ProductSalesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<StaffProduct> StaffProducts { get; set; }

    public virtual DbSet<Stock> Stocks { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source =DESKTOP-5ERBA49\\SQLEXPRESS; Initial Catalog = ProductSales_db;Integrated Security = True;\nTrusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.BrandId).HasName("PK__Brand__DAD4F05EFD59D2EB");

            entity.ToTable("Brand");

            entity.Property(e => e.BrandName).HasMaxLength(30);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Category__19093A0B710F66B0");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryName).HasMaxLength(30);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64D83573AD77");

            entity.Property(e => e.City).HasMaxLength(30);
            entity.Property(e => e.Email).HasMaxLength(30);
            entity.Property(e => e.FirstName).HasMaxLength(30);
            entity.Property(e => e.LastName).HasMaxLength(30);
            entity.Property(e => e.PhoneNumber).HasMaxLength(10);
            entity.Property(e => e.State).HasMaxLength(30);
            entity.Property(e => e.Street).HasMaxLength(30);
            entity.Property(e => e.ZipCode).HasMaxLength(10);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BCF21AA4448");

            entity.Property(e => e.OrderDate).HasColumnType("date");
            entity.Property(e => e.OrderStatus).HasMaxLength(10);
            entity.Property(e => e.RequiredDate).HasColumnType("date");
            entity.Property(e => e.ShippedDate).HasColumnType("date");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Orders__Customer__73BA3083");

            entity.HasOne(d => d.Staff).WithMany(p => p.Orders)
                .HasForeignKey(d => d.StaffId)
                .HasConstraintName("FK__Orders__StaffId__72C60C4A");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK__OrderIte__727E838BF3CB4FEC");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__OrderItem__Order__76969D2E");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__OrderItem__Produ__778AC167");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6CD7319AE91");

            entity.Property(e => e.ProductName).HasMaxLength(30);

            entity.HasOne(d => d.Brand).WithMany(p => p.Products)
                .HasForeignKey(d => d.BrandId)
                .HasConstraintName("FK__Products__BrandI__5BE2A6F2");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Products__Catego__5CD6CB2B");
        });

        modelBuilder.Entity<StaffProduct>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__StaffPro__96D4AB1722A325F2");

            entity.ToTable("StaffProduct");

            entity.Property(e => e.Active).HasMaxLength(2);
            entity.Property(e => e.Email).HasMaxLength(20);
            entity.Property(e => e.FirstName).HasMaxLength(20);
            entity.Property(e => e.LastName).HasMaxLength(20);
            entity.Property(e => e.PhoneNumber).HasMaxLength(10);

            entity.HasOne(d => d.Store).WithMany(p => p.StaffProducts)
                .HasForeignKey(d => d.StoreId)
                .HasConstraintName("FK__StaffProd__Store__6FE99F9F");
        });

        modelBuilder.Entity<Stock>(entity =>
        {
            entity.HasNoKey();

            entity.HasOne(d => d.Product).WithMany()
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Stocks__ProductI__6383C8BA");

            entity.HasOne(d => d.Store).WithMany()
                .HasForeignKey(d => d.StoreId)
                .HasConstraintName("FK__Stocks__StoreId__628FA481");
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasKey(e => e.StoreId).HasName("PK__Stores__3B82F10121840814");

            entity.Property(e => e.City).HasMaxLength(30);
            entity.Property(e => e.Email).HasMaxLength(30);
            entity.Property(e => e.PhoneNumber).HasMaxLength(10);
            entity.Property(e => e.State).HasMaxLength(30);
            entity.Property(e => e.StoreName).HasMaxLength(30);
            entity.Property(e => e.Street).HasMaxLength(30);
            entity.Property(e => e.ZipCode).HasMaxLength(10);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
