using CleanArchitectureBoilerplate.Application.Common.Validation;
using CleanArchitectureBoilerplate.Domain.Entities;
using static CleanArchitectureBoilerplate.Application.Accounts.AccountDTO;

namespace CleanArchitectureBoilerplate.Application.Accounts
{
    public interface IAccountService
    {
        public Task<Result<AccountResponse>> GetAccountById(Guid id);
        public Task<Result<AccountPlan>> GetAccountPlan(Guid id);
        public Task<Result<AccountResponse>> AddAccount(AccountAdd accountAdd);
    }
}