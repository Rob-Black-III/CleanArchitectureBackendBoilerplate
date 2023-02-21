# BackendBoilerplate

Personal Boilerplate for API Projects using .NET CORE 7. WIP
- Using FluentValidation, Serilog, EF Core.

TODO Fix Global Error Handling (Example: Passing malformed GUID causes explosions)
TODO implement layer-specific known-error handling (Try/Catch? Exception Throwing (not performant), Result<>, ErrorOR<>
TODO Abstract Away payload-return of FluentValidation Validate() results from Controller.
TODO use discriminated-union as opposed to exception throwing (ErrorOR<>, Result<>, etc)
