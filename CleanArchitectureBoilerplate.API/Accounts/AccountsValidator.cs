using CleanArchitectureBoilerplate.Application.Common.Validation;
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

                // Don't use NotEmpty for nullable types. It will explode.
                // https://github.com/FluentValidation/FluentValidation/issues/1101
                RuleFor(x => x.AccountPlanId).NotNull();
            }
        }
    }
}