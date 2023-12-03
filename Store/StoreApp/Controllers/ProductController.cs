using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreApp.Models;
using Entities.Models;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        // Dependency Injection 
        private readonly RepositoryContext _context;

        public ProductController(RepositoryContext context)
        {
            _context = context;
        }

        /*
        public IEnumerable<Product> Index()
        {
            /* DI
            var context = new RepositoryContext(
                new DbContextOptionsBuilder<RepositoryContext>()
                    .UseSqlite("Data Source = C:\\Users\\Excalibur\\Desktop\\ASPNET_Core_MVC\\ProductDb.db")
                    .Options
            );
            *
            return _context.Products;
        }
        */

        public IActionResult Index()
        {
            var model = _context.Products.ToList();
            return View(model);
        }

         public IActionResult GetOneProductById(int id)
        {
            Product product = _context.Products.First(p => p.ProductId.Equals(id));
            return View(product);
        }
    }
}