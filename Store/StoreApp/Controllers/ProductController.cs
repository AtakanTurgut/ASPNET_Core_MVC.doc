using Entities.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using StoreApp.Models;

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
            ViewData["Title"] = "Products";
            //var model = _manager.Product.GetAllProducts(false);//.ToList(); == View.Product.Index -> @model List<Product>
            //var model = _manager.ProductService.GetAllProducts(false);//.ToList(); == View.Product.Index -> @model List<Product>
            var products = _manager.ProductService.GetAllProductsWithDetails(p);
            var pagination = new Pagination()
            {
                CurrentPage = p.PageNumber,
                ItemsPerPage = p.PageSize,
                TotalItems = _manager.ProductService.GetAllProducts(false).Count()
            };

            return View(new ProductListViewModel() 
            {
                Products = products,
                Pagination = pagination
            });
        }

         public IActionResult GetOneProductById([FromRoute(Name = "id")] int id)
        {
            var model = _manager.ProductService.GetOneProduct(id, false);
            ViewData["Title"] = model?.ProductName;
            return View(model);
        }
    }
}