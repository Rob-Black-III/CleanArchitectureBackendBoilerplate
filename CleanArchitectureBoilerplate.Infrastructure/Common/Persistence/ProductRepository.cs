using CleanArchitectureBoilerplate.Application.Common.Persistence;
using CleanArchitectureBoilerplate.Domain.Entities;

namespace CleanArchitectureBoilerplate.Infrastructure.Common.Persistence
{
    // EFRepo<T> Gives us generic implementations (getbyid, etc.)
    // IProductRepo gives up product-specific stuff.
    internal class ProductRepository : EFRepository<Product>, IProductRepository
    {
        public ProductRepository(CleanArchitectureBoilerplateDbContext dbContext) : base(dbContext)
        {
        }

        public Task<IEnumerable<string>> GetAllPurchasers()
        {
            throw new NotImplementedException();
        }
        // Parent XREF for categories. 
        // Category object has a reference to Category? parentCategory
        // Product has many List<Categories>? parentCategories 
    }
}