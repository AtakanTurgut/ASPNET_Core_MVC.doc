using Microsoft.AspNetCore.Mvc;
using Repositories;
using Services.Contracts;

namespace StoreApp.Components
{
    public class ProductSummaryViewComponent : ViewComponent
    {
        /*
        private readonly RepositoryContext _context;    // !!!

        public ProductSummary(RepositoryContext context)
        {
            _context = context;
        }

        public String Invoke() 
        {
            return _context.Products.Count().ToString();
        }
        */

        private readonly IServiceManager _manager;

        public ProductSummaryViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        public String Invoke() 
        {
            // service
            return _manager.ProductService.GetAllProducts(false).Count().ToString();
        }

    }
}