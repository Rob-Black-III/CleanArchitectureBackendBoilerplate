using CleanArchitectureBoilerplate.Domain.Entities;
using Mapster;

namespace CleanArchitectureBoilerplate.Application.Products
{
    public class ProductMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.ForType<ProductAdd,Product>().MapToConstructor(true);
            config.ForType<Product,ProductResponse>().MapToConstructor(true);
        }
    }
}