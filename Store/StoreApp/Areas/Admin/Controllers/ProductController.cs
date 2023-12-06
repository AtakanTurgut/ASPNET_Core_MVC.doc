using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index() 
        {
            var model = _manager.ProductService.GetAllProducts(false);
            return View(model);
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] Product product) 
        {
            if (ModelState.IsValid)
            {
                _manager.ProductService.CreateOneProduct(product);
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET
        // Default [HttpGet]
        public IActionResult Update([FromRoute(Name = "id")] int id) 
        {
            var model = _manager.ProductService.GetOneProduct(id, false);
            return View(model);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Product product) 
        {
            if (ModelState.IsValid)
            {
                _manager.ProductService.UpdateOneProduct(product);
                return RedirectToAction("Index");
            }

            return View();            
        }

        // GET
        [HttpGet]
        public IActionResult Delete([FromRoute(Name = "id")] int id) 
        {
            _manager.ProductService.DeleteOneProduct(id);
            return RedirectToAction("Index");
        }

    }
}