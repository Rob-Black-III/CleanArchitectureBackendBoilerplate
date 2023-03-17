using CleanArchitectureBoilerplate.Application.Common.Validation;
using CleanArchitectureBoilerplate.Application.Users;
using CleanArchitectureBoilerplate.Domain.Entities;
using CleanArchitectureBoilerplate.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureBoilerplate.Infrastructure.Users
{
    internal class UsersRepository : EFRepository<User>, IUsersRepository
    {
        public UsersRepository(CleanArchitectureBoilerplateDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Result<bool>> DoesEmailExist(string email)
        {
            return await _dbContext.Users.AnyAsync(x => x.Email == email);
        }

        public async Task<Result<bool>> DoesUsernameExist(string username)
        {
            return await _dbContext.Users.AnyAsync(x => x.Username == username);
        }

        public async Task<Result<List<User>>> GetAllUsers()
        {
            return await _dbContext.Users.AsNoTracking().ToListAsync();
        }
    }
}