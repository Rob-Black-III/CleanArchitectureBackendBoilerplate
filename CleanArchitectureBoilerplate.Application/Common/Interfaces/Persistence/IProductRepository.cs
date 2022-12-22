using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitectureBoilerplate.Domain.Entities;

namespace CleanArchitectureBoilerplate.Application.Common.Interfaces.Persistence
{
    public interface IProductRepository
    {
        // Product-specific queries (get categories perhaps?)
        Task<Product> GetByIdAsync(Guid id);
    }
}