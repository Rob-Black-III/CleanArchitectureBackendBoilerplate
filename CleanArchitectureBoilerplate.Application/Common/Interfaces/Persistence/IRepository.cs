using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitectureBoilerplate.Domain.Common;

namespace CleanArchitectureBoilerplate.Application.Common.Interfaces.Persistence
{
    // Considering getting rid of the generic repository. Considered an anti-pattern.
    // Not all models need all the CRUD operations. Bad design?
    public interface IRepository<T> where T : IAggregateRoot
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<IReadOnlyList<T>> GetPagedReponseAsync(int page, int size);
    }
}