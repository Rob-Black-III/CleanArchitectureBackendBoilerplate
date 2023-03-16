using CleanArchitectureBoilerplate.API.Common.BaseController.ActionResults;
using CleanArchitectureBoilerplate.API.Common.Validation;
using CleanArchitectureBoilerplate.Application.Common.Services;
using CleanArchitectureBoilerplate.Application.Common.Validation;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;

namespace CleanArchitectureBoilerplate.API.Common.BaseController.ActionFilters
{
    public class ValidationModelBindingActionFilter : ActionFilterAttribute
    {
        private readonly ValidationSettings _validationSettings;
        private readonly ICleanArchitectureBoilerplateLogger _logger;
        public ValidationModelBindingActionFilter(ICleanArchitectureBoilerplateLogger logger, IOptions<ValidationSettings> validationOptions)
        {
            _logger = logger;
            _validationSettings = validationOptions.Value;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // ModelState errors are joined with fluentvaliation errors automatically via automatic fluentvalidation.
            if(!context.ModelState.IsValid)
            {
                // Concatenate all error messages.  
                string unsanitizedVerboseValidationErrors = string.Join("; ", context.ModelState.Values
                                            .SelectMany(x => x.Errors)
                                            .Select(x => x.ErrorMessage));

                // Validation Error Logging
                if(_validationSettings.LogUnsanitizedValidationMessages == true)
                {       
                    _logger.LogInfo("Validation failed. " + unsanitizedVerboseValidationErrors);
                }
                else
                {
                    _logger.LogInfo("Validation failed. Details omitted due to appsettings.");
                }

                // Validation Error Client Response
                if(_validationSettings.ShowUnsanitizedValidationMessages == true)
                {

                    // Return the unsanitized error messages. For use in testing and development.
                    context.Result = new FromValidationErrorResult(Error.ValidationError("Validation failed. " + unsanitizedVerboseValidationErrors));
                }
                else
                {
                    // Return a generic error message to avoid leaking unsanitized information.
                    context.Result = new FromValidationErrorResult(Error.ValidationError("Validation failed. Check Your Request Format."));
                }
            }
            else
            {
                _logger.LogInfo("Validation and Model Binding succesful.");
            }

            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            base.OnResultExecuting(context);
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            base.OnResultExecuted(context);
        }
    }
}