using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ASPWebAPIAdminAssignment.Model;

public partial class AdminDbContext : DbContext
{
    public AdminDbContext()
    {
    }

    public AdminDbContext(DbContextOptions<AdminDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Designation> Designations { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //=> optionsBuilder.UseSqlServer("Data Source =DESKTOP-5ERBA49\\SQLEXPRESS; Initial Catalog = Admin_db; Integrated Security = True;\nTrusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Designation>(entity =>
        {
            entity.HasKey(e => e.DesignationId).HasName("PK__Designat__BABD60DEC548E487");

            entity.ToTable("Designation");

            entity.Property(e => e.DesignationName).HasMaxLength(30);
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__Staff__96D4AB172AECD19C");

            entity.Property(e => e.Address).HasMaxLength(30);
            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.Name).HasMaxLength(30);
            entity.Property(e => e.PhoneNumber).HasMaxLength(10);

            entity.HasOne(d => d.Designation).WithMany(p => p.Staff)
                .HasForeignKey(d => d.DesignationId)
                .HasConstraintName("FK__Staff__Designati__4BAC3F29");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
