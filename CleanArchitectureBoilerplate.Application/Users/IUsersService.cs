using CleanArchitectureBoilerplate.Application.Accounts;
using CleanArchitectureBoilerplate.Application.Common.Persistence;
using CleanArchitectureBoilerplate.Application.Common.Validation;
using CleanArchitectureBoilerplate.Domain.Entities;

namespace CleanArchitectureBoilerplate.Application.Users
{
    public interface IUsersService
    {
        // This is more abstract, and will likely me an aggregate of multiple separate repository operations.*
        public Task<Result<UserSingleDTO>> RegisterUser(UserRegisterDTO userRegistrationInfo);

        // Things like this translate directly to SQL, and will likely be duplicated at the repository level.
        public Task<Result<bool>> DoesUsernameExist(string username);

        // Things like this translate directly to SQL, and will likely be duplicated at the repository level.
        public Task<Result<bool>> DoesEmailExist(string email);

        public Task<Result<List<UserSingleDTO>>> GetAllUsers();
    }
}