using CleanArchitectureBoilerplate.Application.Common.Status;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Options;


// https://learn.microsoft.com/en-us/answers/questions/469027/proper-way-of-wrapping-the-response-along-with-exc
// Does not work with primitive payload types.
namespace CleanArchitectureBoilerplate.API.APIResponseWrapper
{
    internal class APIResponseExecutor : ObjectResultExecutor
    {

        private readonly ICleanArchitectureBoilerplateStatusService _statusService;
        public APIResponseExecutor(
            ICleanArchitectureBoilerplateStatusService statusService, 
            OutputFormatterSelector formatterSelector, 
            IHttpResponseStreamWriterFactory writerFactory, 
            ILoggerFactory loggerFactory, 
            IOptions<MvcOptions> mvcOptions) : base(formatterSelector, writerFactory, loggerFactory, mvcOptions)
        {
            _statusService = statusService;
        }

        public override Task ExecuteAsync(ActionContext context, ObjectResult result)
        {
            var response = new ResponseEnvelope<object>();
            response.Payload = result.Value;
            response.TraceID = context.HttpContext.TraceIdentifier;
            response.Issues = _statusService.GetAllStatus();

            // var response = new APIResponse();
            // response.Payload = result.Value;
            // response.TraceID = context.HttpContext.TraceIdentifier;
            // response.Issues = _statusService.GetAllStatus();

            // Does not work with primitive payload types.
            TypeCode? typeCode = Type.GetTypeCode(result.Value.GetType());
            if (typeCode == TypeCode.Object) result.Value = response;

            return base.ExecuteAsync(context, result);
        }
    }
}