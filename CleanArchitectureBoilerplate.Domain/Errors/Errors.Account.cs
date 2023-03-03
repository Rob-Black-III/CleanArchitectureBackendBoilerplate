// using ErrorOr;

// namespace CleanArchitectureBoilerplate.Domain.Errors
// {
//     public static partial class Errors
//     {
//         public static class Account
//         {
//             // For incorrect login
//             public static Error InvalidCredentials => Error.Conflict(code: "User.InvalidCredentials");

//             // For registering a new account
//             public static Error DuplicateEmail => Error.Conflict(code: "User.DuplicateEmail");
//         }
//     }
// }