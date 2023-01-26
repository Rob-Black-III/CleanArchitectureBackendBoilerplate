using CleanArchitectureBoilerplate.Application.Common.Status;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Options;

/*
DEPRECATED
TODO NOT CURRENTLY WORKING. RETURNS {}. WOULD LIKE TO USE THIS INSTEAD OF
RESPONSEWRAPPERMIDDLEWARE.CS IN API/MIDDLEWARE/
https://learn.microsoft.com/en-us/answers/questions/469027/proper-way-of-wrapping-the-response-along-with-exc
*/
namespace CleanArchitectureBoilerplate.API.APIResponseWrapper
{
    internal class APIResponseExecutor : ObjectResultExecutor
    {

        private readonly ICleanArchitectureBoilerplateStatusService _statusService;
        public APIResponseExecutor(ICleanArchitectureBoilerplateStatusService statusService, OutputFormatterSelector formatterSelector, IHttpResponseStreamWriterFactory writerFactory, ILoggerFactory loggerFactory, IOptions<MvcOptions> mvcOptions) : base(formatterSelector, writerFactory, loggerFactory, mvcOptions)
        {
            _statusService = statusService;
        }

        public override Task ExecuteAsync(ActionContext context, ObjectResult result)
        {
            APIResponse response = new APIResponse();
            response.payload = result.Value;
            response.traceID = context.HttpContext.TraceIdentifier;
            response.issues = _statusService.GetAllStatus();

            TypeCode typeCode = Type.GetTypeCode(result.Value.GetType());
            if (typeCode == TypeCode.Object) result.Value = response;

            return base.ExecuteAsync(context, result);
        }
    }
}