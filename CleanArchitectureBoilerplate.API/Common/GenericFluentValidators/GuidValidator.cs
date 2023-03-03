using CleanArchitectureBoilerplate.Application.Common.Validation;
using FluentValidation;

namespace CleanArchitectureBoilerplate.API.Common.GenericFluentValidators
{
    public class GuidValidator : AbstractValidator<Guid>
    {
        public GuidValidator()
        {
            RuleFor(x => x).NotEmpty();
        }
    }
}