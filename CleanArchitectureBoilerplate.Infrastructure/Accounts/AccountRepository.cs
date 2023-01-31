using CleanArchitectureBoilerplate.Application.Accounts;
using CleanArchitectureBoilerplate.Domain.Entities;
using CleanArchitectureBoilerplate.Infrastructure.Common.Persistence;

namespace CleanArchitectureBoilerplate.Infrastructure.Accounts
{
    internal class AccountRepository : EFRepository<Account>, IAccountRepository
    {
        public AccountRepository(CleanArchitectureBoilerplateDbContext dbContext) : base(dbContext)
        {
        }
    }
}