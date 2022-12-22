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
        public async Task<Product> GetByIdAsync(Guid id)
        {
            //var test = await Task.FromResult();
            throw new NotImplementedException();
        }
    }
}