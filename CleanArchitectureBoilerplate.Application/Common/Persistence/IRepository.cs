using System.Linq.Expressions;
using CleanArchitectureBoilerplate.Application.Common.Validation;
using CleanArchitectureBoilerplate.Domain.SeedWork;

namespace CleanArchitectureBoilerplate.Application.Common.Persistence
{
    // Considering getting rid of the generic repository. Considered an anti-pattern.
    // Not all models need all the CRUD operations. Bad design?

    /* 
    Conventions:
    Method names and signatures should describe all of the functionality.
    For instance: 
        Result<T> implies null is not a valid option. It either succeeds and returns, or errors. 'GetById'
        Result<T?> implies null is a valid return type. The method name may be 'TryGetByID'
    */
    public interface IRepository<T> where T : IAggregateRoot
    {
        Task<Result<T>> GetByIdAsync(Guid id);
        Task<Result<bool>> ExistsAsync(Expression<Func<T, bool>> predicate);
        //Task<Result<IQueryable<T?>>> Where(Expression<Func<T, bool>> predicate);
        //Task<Result<IReadOnlyList<T>>> ListAllAsync();
        Task<Result<T>> AddAsync(T entity);
        Task<Result<T>> UpdateAsync(T entity);
        Task<Result<T>> DeleteAsync(T entity);
        Task<Result<IReadOnlyList<T>>> GetPagedReponseAsync(int page, int size);
    }
}