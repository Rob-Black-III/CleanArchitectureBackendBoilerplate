using CleanArchitectureBoilerplate.Application.Common.Interfaces.Validation;
using CleanArchitectureBoilerplate.Application.Products;
using CleanArchitectureBoilerplate.Domain.Entities;
using FluentValidation;

namespace CleanArchitectureBoilerplate.API.Products
{
    public class ProductsCreateValidator : AbstractValidator<ProductAdd>, IAssemblyMarker
    {
        public ProductsCreateValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty().Length(0, Product.MaxDescriptionLength);
        }
    }
}