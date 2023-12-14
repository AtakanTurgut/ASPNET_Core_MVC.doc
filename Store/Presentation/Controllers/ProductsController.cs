using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public ProductsController(IServiceManager manager)
        {
            _manager = manager;
        }

        // GET
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return Ok(_manager.ProductService.GetAllProducts(false));
        }
    }
}