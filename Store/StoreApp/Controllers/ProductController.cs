using Entities.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        // Dependency Injection 
        //private readonly RepositoryContext _context;
        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index(ProductRequestParameters p)
        {
            //var model = _manager.Product.GetAllProducts(false);//.ToList(); == View.Product.Index -> @model List<Product>
            //var model = _manager.ProductService.GetAllProducts(false);//.ToList(); == View.Product.Index -> @model List<Product>
            var model = _manager.ProductService.GetAllProductsWithDetails(p);
            return View(model);
        }

         public IActionResult GetOneProductById([FromRoute(Name = "id")] int id)
        {
            var model = _manager.ProductService.GetOneProduct(id, false);
            return View(model);
        }
    }
}