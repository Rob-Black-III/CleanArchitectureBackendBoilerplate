using CleanArchitectureBoilerplate.Application.Common.Interfaces.Validation;
using FluentValidation;
using static CleanArchitectureBoilerplate.Application.Accounts.AccountDTO;

namespace CleanArchitectureBoilerplate.API.Accounts
{
    public class AccountsValidator
    {
        public class AccountsAddValidator : AbstractValidator<AccountAdd>, IAssemblyMarker
        {
            public AccountsAddValidator()
            {
                RuleFor(x => x.Name).NotEmpty();
                RuleFor(x => x.AccountPlanId).NotEmpty();
            }
        }
    }
}