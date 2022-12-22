using CleanArchitectureBoilerplate.Application.Common.Interfaces.Persistence;

namespace CleanArchitectureBoilerplate.Application.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductResult> GetProductById(Guid id)
        {
            // Get the product from the DB
            var product = await _productRepository.GetByIdAsync(id);

            // Map the DAL "product" to the service-layer ProductResult
            return null;
        }
    }
}