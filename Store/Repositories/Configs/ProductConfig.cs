using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Configs
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ProductId);
            builder.Property(p => p.ProductName).IsRequired();
            builder.Property(p => p.Price).IsRequired();

            builder.HasData(
                    new Product() { ProductId = 1, CategoryId = 1, ProductName = "Computer", Price = 9_500 },
                    new Product() { ProductId = 2, CategoryId = 2, ProductName = "Keyboard", Price = 400 },
                    new Product() { ProductId = 3, CategoryId = 2, ProductName = "Mouse", Price = 550 },
                    new Product() { ProductId = 4, CategoryId = 3, ProductName = "Monitor", Price = 4_800 },
                    new Product() { ProductId = 5, CategoryId = 1, ProductName = "Printer", Price = 3_200 },
                    new Product() { ProductId = 6, CategoryId = 3, ProductName = "Router", Price = 3_200 },
                    new Product() { ProductId = 7, CategoryId = 3, ProductName = "Adapter", Price = 3_200 }
                );
        }
    }
}