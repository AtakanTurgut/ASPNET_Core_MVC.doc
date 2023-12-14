using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contracts;
using StoreApp.Models;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
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

        public IActionResult Index([FromQuery] ProductRequestParameters p) 
        {
            //var model = _manager.ProductService.GetAllProducts(false);
            ViewData["Title"] = "Products";
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

        // GET
        public IActionResult Create()
        {
            ViewData["Title"] = "Create Product";
            //ViewBag.Categories = _manager.CategoryService.GetAllCategories(false);
            TempData["info"] = "Please fill the form.";
            ViewBag.Categories = GetCategoriesSelectList();

            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] ProductDtoForInsertion productDto, IFormFile file) 
        {
            if (ModelState.IsValid)
            {
                // file operation
                string path = Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot","images",file.FileName);          // StoreApp/wwwroot/images/FileName

                using (var stream = new FileStream(path,FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                productDto.ImageUrl = String.Concat("/images/",file.FileName);

                _manager.ProductService.CreateOneProduct(productDto);

                TempData["success"] = $"{productDto.ProductName} has been created.";
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
            ViewData["Title"] = model?.ProductName;
            return View(model);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromForm] ProductDtoForUpdate productDto, IFormFile file) 
        {
            if (ModelState.IsValid)
            {
                // file operations
                string path = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot", 
                    "images",
                    file.FileName);  // StoreApp/wwwroot/images/FileName

                using (var stream = new FileStream(path, FileMode.Create)) 
                {
                    await file.CopyToAsync(stream);
                }

                productDto.ImageUrl = String.Concat("/images/", file.FileName);

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
            TempData["danger"] = "The product has been removed!";
            return RedirectToAction("Index");
        }

    }
}