using Entities.Models;
using Entities.RequestParameters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Repositories.Contracts;
using Repositories.Extensions;

namespace Repositories
{
    public sealed class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext context) : base(context)
        {

        }

        public IQueryable<Product> GetAllProducts(bool trackChanges) => FindAll(trackChanges);

        public IQueryable<Product> GetAllProductsWithDetails(ProductRequestParameters p)
        {
            return _context.Products
                .FilteredByCategoryId(p.CategoryId)
                .FilteredBySearchTerm(p.SearchTerm)
                .FilteredByPrice(p.MinPrice, p.MaxPrice, p.IsValidPrice)
                .ToPaginate(p.PageNumber, p.PageSize);
                //.Where(prd => prd.Price >= p.MinPrice && prd.Price <= p.MaxPrice);
            /*
                p .CategoryId is null
                    ? _context.Products.Include(prd => prd.Category)
                    : _context.Products.Include(prd => prd.Category).Where(prd => prd.CategoryId.Equals(p.CategoryId));
            */
        }

        public IQueryable<Product> GetShowcaseProducts(bool trackChanges)
        {
            return FindAll(trackChanges)
                .Where(p => p.ShowCase.Equals(true));
        }

        // Interface
        public Product? GetOneProduct(int id, bool trackChanges)
        {
            return FindByCondition(p => p.ProductId.Equals(id), trackChanges);
        }

        public void CreateOneProduct(Product product) => Create(product);

        public void DeleteOneProduct(Product product) => Remove(product);

        public void UpdateOneProduct(Product product) => Update(product);

    }
}