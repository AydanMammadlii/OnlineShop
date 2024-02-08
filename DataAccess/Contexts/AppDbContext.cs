using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using OnlineShop.Core.Entities;

namespace DataAccess.Contexts;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Server=LAPTOP-MG65S5V0\SQLEXPRESS;Database=OnlineStoreDb;Trusted_Connection=true;TrustServerCertificate=true;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<Basket>()
            .HasKey(b => b.Id);

        modelBuilder.Entity<User>()
            .HasOne(u => u.Basket)
            .WithOne(b => b.User)
            .HasForeignKey<Basket>(b => b.Id);

        modelBuilder.Entity<BasketProduct>()
            .HasKey(bp => new { bp.ProductId, bp.BasketId });

        modelBuilder.Entity<Product>()
            .HasMany(p => p.BasketProducts)
            .WithOne(bp => bp.Product)
            .HasForeignKey(bp => bp.ProductId);

        modelBuilder.Entity<Basket>()
            .HasMany(p => p.BasketProducts)
            .WithOne(bp => bp.Basket)
            .HasForeignKey(bp => bp.BasketId);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Invoices)
            .WithOne(i => i.User)
            .HasForeignKey(i => i.UserId);

        modelBuilder.Entity<ProductInvoice>()
            .HasKey(pi => new { pi.ProductId, pi.InvoiceId });

        modelBuilder.Entity<Product>()
           .HasMany(p => p.ProductInvoices)
           .WithOne(pi => pi.Product)
           .HasForeignKey(pi => pi.ProductId);

        modelBuilder.Entity<Invoice>()
            .HasMany(i => i.ProductInvoices)
            .WithOne(pi => pi.Invoice)
            .HasForeignKey(pi => pi.InvoiceId);

        modelBuilder.Entity<Wallet>()
            .HasIndex(w => w.CardNumber)
            .IsUnique();

        modelBuilder.Entity<User>()
            .HasMany(u => u.Wallets)
            .WithOne(w => w.User)
        .HasForeignKey(w => w.UserId);

    }
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Basket> Baskets { get; set; } = null!;
    public DbSet<Invoice> Invoices { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Wallet> Wallets { get; set; } = null!;
    public DbSet<BasketProduct> BasketProducts { get; set; } = null!;
    public DbSet<ProductInvoice> ProductInvoices { get; set; } = null!;
}

