using CleanArchitectureBoilerplate.Domain.Entities;
using static CleanArchitectureBoilerplate.Application.Accounts.AccountDTO;

namespace CleanArchitectureBoilerplate.Application.Accounts
{
    public interface IAccountService
    {
        public Task<AccountResponse> GetAccountById(Guid id);
        public AccountPlan GetAccountPlan(Guid id);
        public Task<AccountResponse> AddAccount(AccountAdd accountAdd);
    }
}