using CleanArchitectureBoilerplate.Application.Common.Status;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Options;

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