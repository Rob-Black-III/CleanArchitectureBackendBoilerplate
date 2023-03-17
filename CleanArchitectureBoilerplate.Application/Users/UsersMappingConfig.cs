using CleanArchitectureBoilerplate.Application.Accounts;
using CleanArchitectureBoilerplate.Domain.Entities;
using Mapster;

namespace CleanArchitectureBoilerplate.Application.Users
{
    public class UsersMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.ForType<UserSingleDTO, User>().MapToConstructor(true);
            config.ForType<User, UserSingleDTO>().MapToConstructor(true);
        }
    }
}