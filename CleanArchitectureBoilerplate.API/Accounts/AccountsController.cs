using CleanArchitectureBoilerplate.API.Common;
using CleanArchitectureBoilerplate.Application.Accounts;
using CleanArchitectureBoilerplate.Application.Common.Services;
using CleanArchitectureBoilerplate.Application.Common.Status;
using CleanArchitectureBoilerplate.Application.Common.Validation;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json.Linq;
using static CleanArchitectureBoilerplate.Application.Accounts.AccountDTO;

namespace CleanArchitectureBoilerplate.API.Accounts
{
    [ApiController]
    [Route("[controller]")]
    // Controller base gives us "OK() and BadRequest, 
    // wrappers around OkObjectResult and BadRequestResult, etc
    public class AccountsController : CleanArchitectureBoilerplateController 
    {
        private readonly IAccountService _accountService;
        private readonly ICleanArchitectureBoilerplateStatusService _statusService;
        private readonly ICleanArchitectureBoilerplateLogger _logger;
        //private readonly IMapper _mapper;

        public AccountsController(IAccountService accountService,
            ICleanArchitectureBoilerplateStatusService statusService,
            ICleanArchitectureBoilerplateLogger logger)
        {
            _accountService = accountService;
            _statusService = statusService;
            _logger = logger;
            //_mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            // Get service-layer "ProductResult" (to not expose Domain entities)
            // if(id == default){
            //     return FromError(Error.ValidationError("'Id' must not be null."));
            // }

            Result<AccountResponse> productResult = await _accountService.GetAccountById(id);
            return FromResult(productResult);
        }

        [HttpPost("add")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAccount([FromBody] AccountAdd accountAdd)
        {
            // if(!ModelState.IsValid){
            //     IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
            //     //return FromError(Error.ValidationError(String.Join(Environment.NewLine,allErrors)));
            //     return FromError(Error.ValidationError("Model Binding Failed. Check Your Request Format."));
            // }

            // ValidationResult validationResult = await validator.ValidateAsync(accountAdd);

            // if (!validationResult.IsValid)
            // {
            //     // Log the validation errors
            //     _logger.LogInfo(String.Join(" ", validationResult.Errors));

            //     // Send validation errors back to the frontend for toast and such.
            //     List<string> validationErrors = new List<string>();
            //     validationResult.Errors.ForEach(f => validationErrors.Add(f.ErrorMessage));
            //     return FromError(Error.ValidationError(String.Join(Environment.NewLine, validationErrors)));
            // }

            Result<AccountResponse> addAccountResult = await _accountService.AddAccount(accountAdd);
            return FromResult(addAccountResult);
        }
    }
}