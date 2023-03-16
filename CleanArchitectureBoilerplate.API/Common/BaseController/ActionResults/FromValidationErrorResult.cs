using CleanArchitectureBoilerplate.Application.Common.Validation;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureBoilerplate.API.Common.BaseController.ActionResults
{
    // Naming convention is unfortunate. These results are ActionResults,
    // not my custom Result<> success/fail results.
    // Used in the action filter since we don't have access to the controller.
    public class FromValidationErrorResult : IActionResult
    {
        private readonly Error _result;

        public FromValidationErrorResult(Error result)
        {
            _result = result;
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(_result)
            {
                StatusCode = StatusCodes.Status400BadRequest
            };

            await objectResult.ExecuteResultAsync(context);
        }
    }
}