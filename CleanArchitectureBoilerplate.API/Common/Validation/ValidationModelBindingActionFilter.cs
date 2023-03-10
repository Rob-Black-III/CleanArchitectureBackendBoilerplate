using System.Collections;
using CleanArchitectureBoilerplate.Application.Common.Validation;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CleanArchitectureBoilerplate.API.Common.Validation
{
    public class ValidationModelBindingActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if(!context.ModelState.IsValid)
            {
                // string messages = string.Join("; ", context.ModelState.Values
                //                         .SelectMany(x => x.Errors)
                //                         .Select(x => x.ErrorMessage));
                // context.Result = new FromErrorResult(Error.ValidationError(messages));

                // Don't want to expose underlying architecture information in error.
                context.Result = new FromValidationErrorResult(Error.ValidationError("Model Binding Failed. Check Your Request Format."));
            };
            // IValidator? validator = (IValidator)(context.ActionArguments.First(arg => arg.Value.GetType() == typeof(IValidator))).Value;
            // if (validator is not null)
            // {
            //     // Get the thing to validate
            //     validator.ValidateAsync((IValidationContext)(context.ActionArguments.First(arg => arg.Value.GetType() != typeof(IValidator))).Value);
            // }

            base.OnActionExecuting(context);
        }

        // private async IActionResult? ModelBindAndValidate(Object entityToValidate, IValidator<T> validator) where T : object
        // {
        //     if (!ModelState.IsValid)
        //     {

        //     }

        //     ValidationResult validationResult = await validator.ValidateAsync(entityToValidate);

        //     if (!validationResult.IsValid)
        //     {
        //         // Log the validation errors
        //         //_logger.LogInfo(String.Join(" ", validationResult.Errors));

        //         // Send validation errors back to the frontend for toast and such.
        //         List<string> validationErrors = new List<string>();
        //         validationResult.Errors.ForEach(f => validationErrors.Add(f.ErrorMessage));
        //         return FromError(Error.ValidationError(String.Join(Environment.NewLine, validationErrors)));
        //     }
        //     else
        //     {
        //         return null;
        //     }
        // }
    }
}