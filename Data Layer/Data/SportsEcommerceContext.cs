using System;
using System.Collections.Generic;
using Data_Layer.Models;
using Microsoft.EntityFrameworkCore;

namespace Data_Layer.Data;

public partial class SportsEcommerceContext : DbContext
{
    /*public SportsEcommerceContext()
    {
    }*/

    public SportsEcommerceContext(DbContextOptions<SportsEcommerceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Favourite> Favourites { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<SubCategory> SubCategories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.ToTable("Admin");

            entity.Property(e => e.AdminId)
                .ValueGeneratedNever()
                .HasColumnName("AdminID");
            entity.Property(e => e.AdminName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AdminPassword)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AdminUsername)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.ToTable("Cart");

            entity.Property(e => e.CartId)
                .ValueGeneratedNever()
                .HasColumnName("cartID")
                .HasColumnType("Varchar(50)");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ImageUrl).HasColumnType("varchar(MAX)");
            entity.Property(e => e.Quantity)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("quantity");
            entity.Property(e => e.UserId).HasColumnName("UserID").HasColumnType("varchar(50)");

            entity.HasOne(d => d.Product).WithMany(p => p.Carts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cart_Product");

            entity.HasOne(d => d.User).WithMany(p => p.Carts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cart_User");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.CategoryId)
                .ValueGeneratedNever()
                .HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .IsUnicode(false);

            
        });

        modelBuilder.Entity<Favourite>(entity =>
        {
            entity.ToTable("Favourite");

            entity.Property(e => e.FavouriteId)
                .ValueGeneratedNever()
                .HasColumnName("favouriteID");
            entity.Property(e => e.ProductDescription)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProductImage).HasColumnType("varchar(max)");
            entity.Property(e => e.ProductPrice).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.UserId).HasColumnName("UserID").HasColumnType("varchar(50)");

            entity.HasOne(d => d.Product).WithMany(p => p.Favourites)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Favourite_Product");

            entity.HasOne(d => d.User).WithMany(p => p.Favourites)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Favourite_User");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.ProductId)
                .ValueGeneratedNever()
                .HasColumnName("ProductID");
            entity.Property(e => e.Category)
                .HasColumnType("int");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Quantity)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("quantity");
            entity.Property(e => e.Stock).HasColumnName("stock");
            entity.Property(e => e.SubCategory).HasColumnType("int");
            entity.Property(e => e.IsActive).HasColumnType("bit");
            entity.Property(e => e.ImageUrl).HasColumnType("varchar(MAX)");

            entity.HasOne(d => d.Category1).WithMany(p => p.Products)
                .HasForeignKey(d => d.Category)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Category");

            entity.HasOne(d => d.SubCategory1).WithMany(p => p.Products)
                .HasForeignKey(d => d.SubCategory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_SubCategory");


        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("UserID")
                .HasColumnType("varchar(50)");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserPassword)
                .HasMaxLength(50)
                .IsUnicode(false);
        });
        modelBuilder.Entity<SubCategory>(entity =>
        {
            entity.ToTable("SubCategory");

            entity.Property(e => e.SubcategoryID);
            entity.Property(e => e.SubCategoryName).HasColumnType("varchar(50)");
            entity.Property(e => e.categoryID).HasColumnType("int");

            entity.HasOne(d => d.Category).WithMany(p => p.SubCategories)
                .HasForeignKey(d => d.categoryID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Favourite_User");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
