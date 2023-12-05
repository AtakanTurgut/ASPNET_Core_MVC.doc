using Microsoft.AspNetCore.Mvc;
using Entities.Models;
using Repositories;
using Repositories.Contracts;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        // Dependency Injection 
        //private readonly RepositoryContext _context;
        private readonly IRepositoryManager _manager;

        public ProductController(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var model = _manager.Product.GetAllProducts(false);//.ToList(); == View.Product.Index -> @model List<Product>
            return View(model);
        }

         public IActionResult GetOneProductById(int id)
        {
            var model = _manager.Product.GetOneProduct(id, false);
            return View(model);
        }
    }
}