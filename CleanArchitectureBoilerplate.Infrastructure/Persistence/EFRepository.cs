
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitectureBoilerplate.Application.Common.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureBoilerplate.Infrastructure.Persistence
{
    // https://deviq.com/design-patterns/repository-pattern
    //EFCore already provides the Repository and UnitOfWork via the DBContext and DBSets.
    //However, for testing and to decouple EFCore with our Infrastructure layer,
    //I decided to abstract this to an IRepository for our Application and Infrastructure layers.
    
    public class EFRepository<T> : IRepository<T> where T : class
    {
        protected readonly CleanArchitectureBoilerplateDbContext _dbContext;

        public EFRepository(CleanArchitectureBoilerplateDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
            //return await _dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async virtual Task<IReadOnlyList<T>> GetPagedReponseAsync(int page, int size)
        {
            return await _dbContext.Set<T>().Skip((page - 1) * size).Take(size).AsNoTracking().ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}