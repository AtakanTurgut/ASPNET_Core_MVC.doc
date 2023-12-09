using Repositories.Contracts;

namespace Repositories
{
    public class RepositoryManage : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public RepositoryManage(IProductRepository productRepository, 
            RepositoryContext context, ICategoryRepository categoryRepository )
        {
            _productRepository = productRepository;
            _context = context;
            _categoryRepository = categoryRepository;
        }

        public IProductRepository Product => _productRepository;

        public ICategoryRepository Category => _categoryRepository;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}