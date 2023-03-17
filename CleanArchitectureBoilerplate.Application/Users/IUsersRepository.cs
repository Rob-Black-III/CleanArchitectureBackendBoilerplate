using CleanArchitectureBoilerplate.Application.Common.Persistence;
using CleanArchitectureBoilerplate.Application.Common.Validation;
using CleanArchitectureBoilerplate.Domain.Entities;

namespace CleanArchitectureBoilerplate.Application.Users
{
    // Gets all the common functions defined in IRepository, plus custom functions for Users.
    // This will be what the repo implements to get both.
    public interface IUsersRepository : IRepository<User>
    {
        public Task<Result<List<User>>> GetAllUsers();
        public Task<Result<bool>> DoesUsernameExist(string username);

        // Things like this translate directly to SQL, and will likely be duplicated at the repository level.
        public Task<Result<bool>> DoesEmailExist(string email);
    }
}