# BackendBoilerplate

Personal Boilerplate for API Projects using .NET CORE 7. WIP
- Using FluentValidation, Serilog, EF Core.

TODO Fix Global Error Handling (Example: Passing malformed GUID causes explosions)
TODO implement layer-specific known-error handling (Try/Catch? Exception Throwing (not performant), Result<>, ErrorOR<>
TODO Abstract Away payload-return of FluentValidation Validate() results from Controller.
TODO use discriminated-union as opposed to exception throwing (ErrorOR<>, Result<>, etc)

// There is a [FromQueryRequired] which we don't want, since it throws a 404 (which we override)
// https://stackoverflow.com/questions/7187576/validation-of-guid
// https://stackoverflow.com/questions/50910093/asp-net-core-require-non-nullable-types
// https://stackoverflow.com/questions/43688968/what-does-it-mean-for-a-property-to-be-required-and-nullable

// https://stackoverflow.com/questions/52977418/validate-query-parameters-without-using-a-model-in-netcore-api

// Get service-layer "ProductResult" (to not expose Domain entities)
// if(id == default){
//     return FromError(Error.ValidationError("'Id' must not be null."));
// }

TODO add IConfiguration for ErrorHandling for differnet environments (same way I did ValidationActionFilter)
