using System;
using System.Collections.Generic;
using Company.Models;
using Microsoft.EntityFrameworkCore;

namespace Company.Context;

public partial class CompanyContext : DbContext
{
    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public CompanyContext()
    {
    }

    public CompanyContext(DbContextOptions<CompanyContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost;database=company;user=root");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("departments");

            entity.HasIndex(e => e.LocationId, "location_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.LocationId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("location_id");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");

            entity.HasOne(d => d.Location).WithMany(p => p.Departments)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("departments_ibfk_1");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("employees");

            entity.HasIndex(e => e.DepartmentId, "department_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.DepartmentId)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("int(11)")
                .HasColumnName("department_id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("first_name");
            entity.Property(e => e.HireDate)
                .HasColumnType("date")
                .HasColumnName("hire_date");
            entity.Property(e => e.LastName)
                .HasMaxLength(25)
                .HasColumnName("last_name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("phone_number");
            entity.Property(e => e.Salary)
                .HasPrecision(8)
                .HasColumnName("salary");

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("employees_ibfk_2");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("locations");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(40)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("address");
            entity.Property(e => e.City)
                .HasMaxLength(30)
                .HasColumnName("city");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(12)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("postal_code");
            entity.Property(e => e.StateProvince)
                .HasMaxLength(25)
                .HasDefaultValueSql("'NULL'")
                .HasColumnName("state_province");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
