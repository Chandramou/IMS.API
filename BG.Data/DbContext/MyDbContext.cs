using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BG.Data.Models;

public partial class MyDbContext : DbContext
{

	public MyDbContext(DbContextOptions<MyDbContext> options)
		: base(options)
	{
	}

	public virtual DbSet<Category> Categories { get; set; }

	public virtual DbSet<Order> Orders { get; set; }

	public virtual DbSet<Product> Products { get; set; }

	public virtual DbSet<Purchase> Purchases { get; set; }

	public virtual DbSet<Supplier> Suppliers { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		=> optionsBuilder.UseSqlServer("Data Source=LAPTOP-QQ3AD7GC\\SQLEXPRESS;Initial Catalog=IMS-DB;Integrated Security=True;Encrypt=False");

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Category>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PK__Category__3214EC0745E876D1");

			entity.ToTable("Category");

			entity.Property(e => e.Description).HasMaxLength(100);
			entity.Property(e => e.Name).HasMaxLength(100);
		});

		modelBuilder.Entity<Order>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PK__Orders__3214EC079ED12E08");

			entity.Property(e => e.ConfirmDate).HasColumnType("datetime");
			entity.Property(e => e.OrderDate).HasColumnType("datetime");
			entity.Property(e => e.ShippingAddress).HasMaxLength(255);

			entity.HasOne(d => d.Product).WithMany(p => p.Orders)
				.HasForeignKey(d => d.ProductId)
				.HasConstraintName("FK__Orders__ProductI__2E1BDC42");
		});

		modelBuilder.Entity<Product>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PK__Product__3214EC074EE184B9");

			entity.ToTable("Product");

			entity.Property(e => e.BarCode).HasMaxLength(100);
			entity.Property(e => e.Name).HasMaxLength(100);
			entity.Property(e => e.PurchasingPrice).HasColumnType("money");
			entity.Property(e => e.SellingPrice).HasColumnType("money");
			entity.Property(e => e.Sku)
				.HasMaxLength(50)
				.IsUnicode(false)
				.HasColumnName("SKU");

			entity.HasOne(d => d.Category).WithMany(p => p.Products)
				.HasForeignKey(d => d.CategoryId)
				.HasConstraintName("FK__Product__Categor__2A4B4B5E");

			entity.HasOne(d => d.Supplier).WithMany(p => p.Products)
				.HasForeignKey(d => d.SupplierId)
				.HasConstraintName("FK__Product__Supplie__2B3F6F97");
		});

		modelBuilder.Entity<Purchase>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PK__Purchase__3214EC078F2F7F99");

			entity.ToTable("Purchase");

			entity.Property(e => e.CreatedTime).HasColumnType("datetime");
			entity.Property(e => e.Description).HasMaxLength(500);

			entity.HasOne(d => d.Product).WithMany(p => p.Purchases)
				.HasForeignKey(d => d.ProductId)
				.HasConstraintName("FK__Purchase__Produc__30F848ED");
		});

		modelBuilder.Entity<Supplier>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PK__Supplier__3214EC078EE131AF");

			entity.ToTable("Supplier");

			entity.Property(e => e.Adress).HasMaxLength(255);
			entity.Property(e => e.Email).HasMaxLength(100);
			entity.Property(e => e.Name).HasMaxLength(100);
			entity.Property(e => e.PhoneNumber).HasMaxLength(20);
		});

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
