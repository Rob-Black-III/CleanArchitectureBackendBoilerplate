using CleanArchitectureBoilerplate.Application.Accounts;
using CleanArchitectureBoilerplate.Application.Common.Services;
using CleanArchitectureBoilerplate.Application.Common.Validation;
using CleanArchitectureBoilerplate.Application.Users;
using CleanArchitectureBoilerplate.Domain.Entities;
using MapsterMapper;

namespace CleanArchitectureBoilerplate.Infrastructure.Users
{
    public class UsersService : IUsersService
    {
        private readonly ICleanArchitectureBoilerplateLogger _logger;
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;

        public UsersService(ICleanArchitectureBoilerplateLogger logger, IUsersRepository usersRepository, IMapper _mapper)
        {
            _logger = logger;
            _usersRepository = usersRepository;
        }

        public async Task<Result<bool>> DoesEmailExist(string email)
        {
            // Map to our DAL object from our DTO object (in this case no mapping is required)

            // Do our normal operation, which is abstracted away by the repository layer.
            Result<bool> doesEmailExistOperation = await _usersRepository.DoesEmailExist(email);
            return doesEmailExistOperation;

            // If a lower-layer failed, let that error bubble up and return.
            // Don't need to do that since we are only doing one thing. No need to short-circuit.
            // if(doesEmailExistOperation.IsFaulted)
            // {
            //     return doesEmailExistOperation.Error;
            // }

            // // Map to our DTO object from our DAL object (in this case no mapping is required)

            // return doesEmailExistOperation.Value;
        }

        public Task<Result<bool>> DoesUsernameExist(string username)
        {
            // Don't know if it succeeded or not. But since we don't need to do anything else at this layer
            // for instance, short-circuit in the event we needed to reach out to multiple repositories,
            // we can let higher layers handle it and let it 'bubble-up'
            return _usersRepository.DoesUsernameExist(username);
        }

        public async Task<Result<List<UserSingleDTO>>> GetAllUsers()
        {
            // Don't need to map from requestDTO (non-existent)

            // Hit the repository layer, and get the DAL response.
            Result<List<User>> getAllUsersOperation = await _usersRepository.GetAllUsers();

            if(getAllUsersOperation.IsFaulted)
            {
                return getAllUsersOperation.Error;
            }

            // Map the DAL response to the DTO response. (List<User> --> List<UserSingle>)
            return _mapper.Map<List<UserSingleDTO>>(getAllUsersOperation.Value);

            
        }

        public async Task<Result<UserSingleDTO>> RegisterUser(UserRegisterDTO userRegistrationInfo)
        {
            // Map our UserRegisterDTO to our DAL layer User
            User userToAdd = _mapper.Map<User>(userRegistrationInfo);

            // Automagically do the actual request, abstracted away from us in the repo layer.
            Result<User> userAddedOperation = await _usersRepository.AddAsync(userToAdd);

            // On failure, short circuit and bubble up, let the controller 'FromResult' handle it.
            if(userAddedOperation.IsFaulted)
            {
                return userAddedOperation.Error;
            }

            // On success, map our User to our UserSingleDTO.
            return _mapper.Map<UserSingleDTO>(userAddedOperation.Value);
        }
    }
}