using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureBoilerplate.API.Common
{
    // https://stackoverflow.com/questions/49503802/mvc-core-iactionresult-meaning
    public class FromSuccessResultActionResult<T> : IActionResult
    {
        private readonly T _successType;
        private HttpStatusCode _statusCode;

        public FromSuccessResultActionResult(T successType, HttpStatusCode statusCode)
        {
            _successType = successType;
            _statusCode = statusCode;
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(_successType)
            {
                StatusCode = ((int)_statusCode)
            };

            await objectResult.ExecuteResultAsync(context);
        }
    }
}