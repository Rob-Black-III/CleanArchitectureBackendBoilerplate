using CleanArchitectureBoilerplate.Application.Common.Interfaces.Persistence;
using CleanArchitectureBoilerplate.Application.Common.Services;
using CleanArchitectureBoilerplate.Application.Common.Status;
using CleanArchitectureBoilerplate.Domain.Entities;
using Mapster;
using MapsterMapper;

namespace CleanArchitectureBoilerplate.Application.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICleanArchitectureBoilerplateLogger _logger;
        private readonly ICleanArchitectureBoilerplateStatusService _statusService;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, ICleanArchitectureBoilerplateStatusService statusService, ICleanArchitectureBoilerplateLogger logger, IMapper mapper)
        {
            _productRepository = productRepository;
            _statusService = statusService;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ProductResult> CreateProduct(ProductAdd productAdd)
        {
            // Map the ProductAdd DTO to a Product
            Product productToAdd = _mapper.Map<Product>(productAdd);

            // Add the product and get it back as confirmation. Should have GUID
            Product p = await _productRepository.AddAsync(productToAdd);

            // Return the Result DTO of the newly-added product.
            return _mapper.Map<ProductResult>(p);
        }

        public async Task<ProductResult> GetProductById(Guid id)
        {
            // Get the product from the DB
            Product p = await _productRepository.GetByIdAsync(id);

            // Map the DAL "product" to the service-layer ProductResult
            return _mapper.Map<ProductResult>(p);
        }
    }
}