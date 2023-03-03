// using FluentValidation;

// namespace CleanArchitectureBoilerplate.API.Common
// {
//     public static class FluentValidationExtensions
//     {
//         public static IRuleBuilderOptions<T, Guid> GUIDNotDefault<T, TElement>(this IRuleBuilder<T, Guid> ruleBuilder)
//         {
//             return ruleBuilder.Must(g => g != default).WithMessage("Guid must not be default.");
//         }
        
//     }
// }