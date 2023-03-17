
using System.Linq.Expressions;
using CleanArchitectureBoilerplate.Application.Common.Persistence;
using CleanArchitectureBoilerplate.Application.Common.Validation;
using CleanArchitectureBoilerplate.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureBoilerplate.Infrastructure.Common.Persistence
{
    // https://deviq.com/design-patterns/repository-pattern
    //EFCore already provides the Repository and UnitOfWork via the DBContext and DBSets.
    //However, for testing and to decouple EFCore with our Infrastructure layer,
    //I decided to abstract this to an IRepository for our Application and Infrastructure layers.

    // For our purposes, "repository" is just a specific type of "service".
    // Services should be in the infrastructure layer
    
    abstract internal class EFRepository<T> : IRepository<T> where T : class, IAggregateRoot
    {
        protected readonly CleanArchitectureBoilerplateDbContext _dbContext;

        public EFRepository(CleanArchitectureBoilerplateDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // public async Task<IReadOnlyList<T>> ListAllAsync()
        // {
        //     return await _dbContext.Set<T>().ToListAsync();
        // }

        public async Task<Result<T>> GetByIdAsync(Guid id)
        {
            try
            {
                if(id == default)
                {
                    return Error.ValidationError("'Id' must not be null or empty.");
                }

                T? foundEntity = await _dbContext.Set<T>().FindAsync(id);
                if (foundEntity is not null)
                {
                    return foundEntity;
                }
                else
                {
                    return Error.NotFoundError("No entities exist for the provided id.");
                }
            }
            catch
            {
                return Error.UnknownError($"An unknown error occured while checking if any {typeof(T)}'s satisfy the provided condition.");

            }
        }

        public async Task<Result<bool>>ExistsAsync(Expression<Func<T, bool>> predicate)
        {
            // Since true or false are both valid, 
            // we want to only catch any other random stuff (network errors, sql, etc.)
            try
            {
                bool anyExist = await _dbContext.Set<T>().AnyAsync(predicate);
                return anyExist;
            }
            catch
            {
                return Error.UnknownError($"An unknown error occured while checking if any {typeof(T)}'s satisfy the provided condition.");
            }
            

        }

        // Task<Result<IQueryable<T?>>> Where(Expression<Func<T, bool>> predicate)
        // {
        //     try
        //     {
        //         return _dbContext.Set<T>().Where(predicate);
        //     }
        //     catch(ArgumentNullException e)
        //     {
        //         return Error.UnknownError("Provided predicate was null.");
        //     }
        //     catch (Exception e)
        //     {
        //         return Error.UnknownError($"An unknown error occured while checking if any {typeof(T)}'s satisfy the provided 'where' condition.");

        //     }
            
        // }

        public async Task<Result<T>> AddAsync(T entity)
        {
            try
            {
                await _dbContext.Set<T>().AddAsync(entity);
                await _dbContext.SaveChangesAsync();

                // Id will be automagically filled in.
                return entity;
            }
            catch
            {
                return Error.UnknownError($"An unknown error occured while adding {typeof(T)} to the database.");
            }
        }

        public async Task<Result<T>> UpdateAsync(T entity)
        {
            try
            {
                _dbContext.Set<T>().Update(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch
            {
                return Error.UnknownError($"An unknown error occured while updating {typeof(T)} in the database.");
            }

        }

        public async Task<Result<T>> DeleteAsync(T entity)
        {
            try
            {
                _dbContext.Set<T>().Remove(entity);
                await _dbContext.SaveChangesAsync();
                return entity; // Work around not wanting to return bool void.
            }
            catch
            {
                return Error.UnknownError($"An unknown error occured while deleting {typeof(T)} from the database.");
            }

        }

        public async Task<Result<IReadOnlyList<T>>> GetPagedReponseAsync(int page, int size)
        {
            try
            {
                return await _dbContext.Set<T>().Skip((page - 1) * size).Take(size).AsNoTracking().ToListAsync();
            }
            catch(ArgumentNullException e)
            {
                return Error.ValidationError($"Parameters 'page' or 'size' returned null.");

            }
            catch (Exception e)
            {
                return Error.UnknownError($"An unknown error occured while deleting {typeof(T)} from the database.");

            }
            
        }

        // Decided against this. Wanted all to be a case-by-case basis, based on the potential for misuse.
        // Cannot be async (only used for further chained queries)
        // public async Task<Result<List<T>>> GetAll()
        // {
        //     try
        //     {
        //         return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        //     }
        //     catch
        //     {
        //         return Error.UnknownError($"An unknown error occured while getting all {typeof(T)}'s from the database.");
        //     }

        // }
    }
}