using CleanArchitectureBoilerplate.Domain.Entities;

namespace CleanArchitectureBoilerplate.Application.Common.Persistence
{
    // Our product repo should also have generic repository operations. IRepository<Product>
    // In addition to custom operations defined here. IProductRepository

    // Should inject the interface since we don't care about EF in this layer
    public interface IProductRepository : IRepository<Product>
    {
        // Product-specific queries (get categories perhaps?)
        Task<IEnumerable<string>> GetAllPurchasers();
    }
}