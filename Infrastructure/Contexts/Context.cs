using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Contexts
{
    public class Context : DbContext
    {
        public Context() : base(){}
        public Context(DbContextOptions options) : base(options) { 
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Proporsal>()
                .HasMany(p => p.Prices)
                .WithOne(p => p.Proporsal)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Price>()
                .HasMany<ProductQuotation>(p => p.ProductQuotations)
                .WithOne(p => p.Price)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ProductProvider>()
                .HasKey(pp => new { pp.ProductId, pp.ProviderId });

            builder.Entity<ProductProvider>()
                .HasOne(pp => pp.Product)
                .WithMany(p => p.Providers)
                .HasForeignKey(pp => pp.ProductId);

            builder.Entity<ProductProvider>()
                .HasOne(pp => pp.Provider)
                .WithMany(p => p.Products)
                .HasForeignKey(pp => pp.ProviderId);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        
        }
        public virtual DbSet<ProductProvider> ProductProviders { get; set; }
        public virtual DbSet<ProductQuotation> ProductQuotations { get; set; }
        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Proporsal> Proporsals { get; set; }
        public virtual DbSet<Provider> Provider { get; set; }
        public virtual DbSet<Purchaser> Purchaser { get; set; }
        public virtual DbSet<SupplyOrder> SupplyOrders { get; set; }
    }
}
