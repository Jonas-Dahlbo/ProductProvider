using System;
using System.Collections.Generic;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Color> Colors { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Price> Prices { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Size> Sizes { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=tcp:rikaproductdb.database.windows.net,1433;Initial Catalog=RikaProductDB;Persist Security Info=False;User ID=rikaproductadmin;Password=BytMig123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC078E8DF67A");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Icon).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Color>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Colors__3214EC07D310433A");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Hexadecimal_color)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Images__3214EC0707C059CC");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Image_URL).HasMaxLength(255);

            entity.HasOne(d => d.Product).WithMany(p => p.Images)
                .HasForeignKey(d => d.Product_id)
                .HasConstraintName("FK__Images__Product___656C112C");
        });

        modelBuilder.Entity<Price>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Prices__3214EC079EAAE1FF");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Discount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Discount_price).HasColumnType("money");
            entity.Property(e => e.End_date).HasColumnType("datetime");
            entity.Property(e => e.Price1)
                .HasColumnType("money")
                .HasColumnName("Price");
            entity.Property(e => e.Start_date).HasColumnType("datetime");

            entity.HasOne(d => d.Product).WithMany(p => p.Prices)
                .HasForeignKey(d => d.Product_id)
                .HasConstraintName("FK__Prices__Product___6FE99F9F");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC078C0F8A56");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Created_at)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Long_description).HasColumnType("text");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Short_description).HasColumnType("text");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.Category_id)
                .HasConstraintName("FK__Products__Catego__628FA481");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reviews__3214EC072FAF0DA6");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Text).HasColumnType("text");

            entity.HasOne(d => d.Product).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.Product_id)
                .HasConstraintName("FK__Reviews__Product__68487DD7");
        });

        modelBuilder.Entity<Size>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sizes__3214EC078CBDF272");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.HasKey(e => e.Unique_product_id).HasName("PK__Warehous__3D606B39CEEDD5EF");

            entity.ToTable("Warehouse");

            entity.Property(e => e.Unique_product_id).ValueGeneratedNever();

            entity.HasOne(d => d.Color).WithMany(p => p.Warehouses)
                .HasForeignKey(d => d.Color_id)
                .HasConstraintName("FK__Warehouse__Color__6C190EBB");

            entity.HasOne(d => d.Product).WithMany(p => p.Warehouses)
                .HasForeignKey(d => d.Product_id)
                .HasConstraintName("FK__Warehouse__Produ__6B24EA82");

            entity.HasOne(d => d.Size).WithMany(p => p.Warehouses)
                .HasForeignKey(d => d.Size_id)
                .HasConstraintName("FK__Warehouse__Size___6D0D32F4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
