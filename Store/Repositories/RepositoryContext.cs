﻿using Microsoft.EntityFrameworkCore;
using Entities.Models;

namespace Repositories
{
    public class RepositoryContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
                .HasData(
                    new Product() { ProductId = 1, ProductName = "Computer", Price = 9_500 },
                    new Product() { ProductId = 2, ProductName = "Keyboard", Price = 400 },
                    new Product() { ProductId = 3, ProductName = "Mouse", Price = 550 },
                    new Product() { ProductId = 4, ProductName = "Monitor", Price = 4_800 },
                    new Product() { ProductId = 5, ProductName = "Printer", Price = 3_200 }
                );

            modelBuilder.Entity<Category>()
                .HasData(
                    new Category() { CategoryId = 1, CategoryName = "Electronic" },
                    new Category() { CategoryId = 2, CategoryName = "Accessory" },
                    new Category() { CategoryId = 3, CategoryName = "External" }
                );
        }

    }
}