namespace CleanArchitectureBoilerplate.Application.Products
{
    public interface IProductService
    {
        Task<ProductResult> GetProductById(Guid id);
    }
}