using System.Linq.Expressions;
using CleanArchitectureBoilerplate.Application.Common.Validation;
using CleanArchitectureBoilerplate.Domain.SeedWork;

namespace CleanArchitectureBoilerplate.Application.Common.Persistence
{
    // Common functions we want for everything.

    /* 
    Conventions:
    Method names and signatures should describe all of the functionality.
    For instance: 
        Result<T> implies null is not a valid option. It either succeeds and returns, or errors. 'GetById'
        Result<T?> implies null is a valid return type. The method name may be 'TryGetByID'
    */
    public interface IRepository<T> where T : IAggregateRoot
    {
        //Result<List<T>> GetAll(); // Only when you use when you actually want ALL. Should filter in db otherwise.
        Task<Result<T>> GetByIdAsync(Guid id);
        Task<Result<bool>> ExistsAsync(Expression<Func<T, bool>> predicate);    
        Task<Result<T>> AddAsync(T entity);
        Task<Result<T>> UpdateAsync(T entity);
        Task<Result<T>> DeleteAsync(T entity);
        Task<Result<IReadOnlyList<T>>> GetPagedReponseAsync(int page, int size);
    }
}