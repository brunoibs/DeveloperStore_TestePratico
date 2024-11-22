using System;
using System.Collections.Generic;
using DeveloperStore.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace DeveloperStore.Data;

public partial class masterContext : DbContext
{
    public masterContext()
    {
    }

    public masterContext(DbContextOptions<masterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Product_Sale> Product_Sales { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=master;Persist Security Info=True;User ID=sa;Password=Admin@2024;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Produto__3214EC074EBE6ACE");
        });

        modelBuilder.Entity<Product_Sale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Product_Sales_pk");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Product_Sales)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Product_Sales_fk2");

            entity.HasOne(d => d.IdSalesNavigation).WithMany(p => p.Product_Sales)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Product_Sales_fk");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sale__3214EC073876BDCC");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}