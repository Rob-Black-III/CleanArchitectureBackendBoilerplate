using System.Net;
using CleanArchitectureBoilerplate.API.Common.Validation;
using CleanArchitectureBoilerplate.Application.Common.Validation;
using CleanArchitectureBoilerplate.Domain.SeedWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CleanArchitectureBoilerplate.API.Common
{
    [ServiceFilter(typeof(ValidationModelBindingActionFilter))]
    [BindingBehavior(BindingBehavior.Optional)]
    public class CleanArchitectureBoilerplateController : ControllerBase
    {

        protected IActionResult FromResult<T>(Result<T> result)
        {
            // By default, on success, return
            return result.Match(
                (successPayload) => SuccessToHTTPStatusIActionResult<T>(successPayload),
                (error) => ErrorToHTTPStatusIActionResult(error)
                );
        }

         protected IActionResult FromResult<T>(Result<T> result, HttpStatusCode onSuccessStatusCode)
        {
            // By default, on success, return
            return result.Match(
                (successPayload) => SuccessToHTTPStatusIActionResult<T>(successPayload, onSuccessStatusCode),
                (error) => ErrorToHTTPStatusIActionResult(error)
                );
        }

        // Should only be used in the controller for controller-level errors (validation)
        protected IActionResult FromError(Error error)
        {
            return ErrorToHTTPStatusIActionResult(error);
        }

        // Shorthand to return 200 on all success request, unless otherwise specfied.
        private IActionResult SuccessToHTTPStatusIActionResult<T>(T success)
        {
            return new FromSuccessResultActionResult<T>(success, HttpStatusCode.OK);
        }

        // Return a payload with any status code.
        private IActionResult SuccessToHTTPStatusIActionResult<T>(T success, HttpStatusCode statusCode)
        {
            return new FromSuccessResultActionResult<T>(success, statusCode);
        }

        // Maps our Domain error types to our HTTP error types as an abstraction layer.
        private IActionResult ErrorToHTTPStatusIActionResult(Error e) => e.ErrorType switch
        {
            // Can be found in the CustomIActionResults.cs file
            ErrorType.Validation => new FromValidationErrorResult(e),
            ErrorType.NotFound => base.NotFound(e),
            ErrorType.Conflict => base.Conflict(e),

            // For other error types (error is handled, just don't know how to translate to HTTP codes)
            // _ => base.StatusCode(500)
        };

        // TODO move all the model binding validation errors and fluent validation errors to a middleware or actionfilter or ControllerBase extension method
        // **** https://stackoverflow.com/questions/42582758/asp-net-core-middleware-vs-filters ****
        // OR 
        // https://stackoverflow.com/questions/59922693/fluentvalidation-use-custom-iactionfilter
        // https://medium.com/@sergiobarriel/how-to-automatically-validate-a-model-with-mvc-filter-and-fluent-validation-package-ae51098bcf5b
        // https://stackoverflow.com/questions/40932102/fluentvalidation-and-actionfilterattribute-update-model-before-it-is-validated

        // older naive 
        // https://stackoverflow.com/questions/13684354/validating-a-view-model-after-custom-model-binding

        // Fuck all this garbage and gonna do this
        // https://stackoverflow.com/questions/74246450/auto-api-validation-with-fluentvalidation

        // Result object stuff
        // https://enterprisecraftsmanship.com/posts/error-handling-exception-or-result/
    }
}