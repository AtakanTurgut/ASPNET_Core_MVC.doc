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
                    new Product() { ProductId = 1, CategoryId = 1, ImageUrl = "/images/computer.jpg", ProductName = "Computer", Price = 9_500, ShowCase = true },
                    new Product() { ProductId = 2, CategoryId = 2, ImageUrl = "/images/keyboard.jpg", ProductName = "Keyboard", Price = 400, ShowCase = false },
                    new Product() { ProductId = 3, CategoryId = 2, ImageUrl = "/images/mouse.jpg", ProductName = "Mouse", Price = 550, ShowCase = false },
                    new Product() { ProductId = 4, CategoryId = 3, ImageUrl = "/images/monitor.jpg", ProductName = "Monitor", Price = 4_800, ShowCase = false },
                    new Product() { ProductId = 5, CategoryId = 1, ImageUrl = "/images/printer.jpg", ProductName = "Printer", Price = 3_200, ShowCase = true },
                    new Product() { ProductId = 6, CategoryId = 3, ImageUrl = "/images/router.jpg", ProductName = "Router", Price = 5_500, ShowCase = false },
                    new Product() { ProductId = 7, CategoryId = 3, ImageUrl = "/images/adapter.jpg", ProductName = "Adapter", Price = 920, ShowCase = false },
                    new Product() { ProductId = 8, CategoryId = 1, ImageUrl = "/images/smartphone.jpg", ProductName = "Smartphone", Price = 13_800, ShowCase = false },
                    new Product() { ProductId = 9, CategoryId = 2, ImageUrl = "/images/webcam.jpg", ProductName = "Webcam", Price = 230, ShowCase = false },
                    new Product() { ProductId = 10, CategoryId = 1, ImageUrl = "/images/tablet.jpg", ProductName = "Tablet", Price = 6_400, ShowCase = true }
                );
                                                                // StoreApp/wwwroot/images/..jpg
        }
    }
}