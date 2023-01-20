using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitectureBoilerplate.Application.Common.Interfaces.Persistence;
using CleanArchitectureBoilerplate.Domain.Entities;

namespace CleanArchitectureBoilerplate.Infrastructure.Persistence
{
    public class ProductRepository : IProductRepository
    {
        // Parent XREF for categories. 
        // Category object has a reference to Category? parentCategory
        // Product has many List<Categories>? parentCategories 
        public async Task<Product> GetByIdAsync(Guid id)
        {
            //var test = await Task.FromResult();
            throw new NotImplementedException();
        }
    }
}