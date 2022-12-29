using CleanArchitectureBoilerplate.Application.Common.Interfaces.Validation;
using FluentValidation;
using static CleanArchitectureBoilerplate.API.Authentication.AuthenticationPresentationDTOs;

namespace CleanArchitectureBoilerplate.API.Authentication
{
    public class AuthenticationRegisterRequestValidator : AbstractValidator<RegisterRequest>, IAssemblyMarker
    {
        public AuthenticationRegisterRequestValidator() {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().NotNull().EmailAddress();
            RuleFor(x => x.Password).NotEmpty().NotNull().Length(12,20);
        }   
    }

    public class AuthenticationLoginRequestValidator : AbstractValidator<LoginRequest>, IAssemblyMarker
    {
        public AuthenticationLoginRequestValidator() {
            RuleFor(x => x.Email).NotEmpty().NotNull().EmailAddress();
            RuleFor(x => x.Password).NotEmpty().NotNull().Length(12,20);
        }   
    }
}