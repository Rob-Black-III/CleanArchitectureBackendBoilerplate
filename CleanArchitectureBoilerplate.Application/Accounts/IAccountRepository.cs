using CleanArchitectureBoilerplate.Application.Common.Interfaces.Persistence;
using CleanArchitectureBoilerplate.Domain.Entities;

namespace CleanArchitectureBoilerplate.Application.Accounts
{
    // Has to be in application layer, has to implement IRepository<Account> for injection
    public interface IAccountRepository : IRepository<Account>
    {
        
    }
}