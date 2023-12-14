using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Controllers
{
    public class CategoryController : Controller
    {
        //private IRepositoryManager _manager;
        private readonly IServiceManager _manager;

        public CategoryController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Categories";
            //var model = _manager.Category.FindAll(false);
            var model = _manager.CategoryService.GetAllCategories(false);
            return View(model);
        }
    }
}