using CleanArchitectureBoilerplate.Application.Common.Validation;
using FluentValidation;
using static CleanArchitectureBoilerplate.Application.Accounts.AccountDTO;
using CleanArchitectureBoilerplate.API.Common.GenericFluentValidators;

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
                // Don't use notempty because we want null, just not Guid.Empty
                // 00000000-0000-0000-0000-000000000000
                RuleFor(x => x.AccountPlanId).NotEqual(Guid.Empty).WithMessage("Guid cannot be empty or default.");
            }
        }
    }
}