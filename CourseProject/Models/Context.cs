using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.Models
{
    public class Context : IdentityDbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFabric> Fabrics { get; set; }
        public DbSet<ProductSize> Sizes { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseProduct> PurchaseProducts { get; set; }
        public DbSet<Viewed> Vieweds { get; set; }

        public Context(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductFabric>().HasKey(ep => new { ep.ProductId, ep.Fabric });
            modelBuilder.Entity<ProductSize>().HasKey(ep => new { ep.ProductId, ep.Size });
            modelBuilder.Entity<PurchaseProduct>().HasKey(ep => new { ep.ProductId, ep.PurchaseId });
            modelBuilder.Entity<Viewed>().HasKey(ep => new { ep.ProductId, ep.CustomerId });
        }
    }
}
