namespace CleanArchitectureBoilerplate.Application.Products
{
    public interface IProductService
    {
        Task<ProductResult> GetProductById(Guid id);

        Task<ProductResult> CreateProduct(ProductAdd productAdd);
    }
}