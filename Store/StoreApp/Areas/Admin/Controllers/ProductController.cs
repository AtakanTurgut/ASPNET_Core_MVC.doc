using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        
        private SelectList GetCategoriesSelectList() 
        {
            return new SelectList(_manager.CategoryService.GetAllCategories(false), "CategoryId", "CategoryName", "1");
        }

        public IActionResult Index() 
        {
            var model = _manager.ProductService.GetAllProducts(false);
            return View(model);
        }

        // GET
        public IActionResult Create()
        {
            //ViewBag.Categories = _manager.CategoryService.GetAllCategories(false);
            ViewBag.Categories = GetCategoriesSelectList();

            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] ProductDtoForInsertion productDto) 
        {
            if (ModelState.IsValid)
            {
                _manager.ProductService.CreateOneProduct(productDto);
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET
        // Default [HttpGet]
        public IActionResult Update([FromRoute(Name = "id")] int id) 
        {
            ViewBag.Categories = GetCategoriesSelectList();

            var model = _manager.ProductService.GetOneProductForUpdate(id, false);
            return View(model);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([FromForm] ProductDtoForUpdate productDto) 
        {
            if (ModelState.IsValid)
            {
                _manager.ProductService.UpdateOneProduct(productDto);
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