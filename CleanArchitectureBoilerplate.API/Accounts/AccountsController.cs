using CleanArchitectureBoilerplate.Application.Accounts;
using CleanArchitectureBoilerplate.Application.Common.Services;
using CleanArchitectureBoilerplate.Application.Common.Status;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using static CleanArchitectureBoilerplate.Application.Accounts.AccountDTO;

namespace CleanArchitectureBoilerplate.API.Accounts
{
    [ApiController]
    [Route("[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ICleanArchitectureBoilerplateStatusService _statusService;
        private readonly ICleanArchitectureBoilerplateLogger _logger;
        //private readonly IMapper _mapper;

        public AccountsController(IAccountService accountService, ICleanArchitectureBoilerplateStatusService statusService, ICleanArchitectureBoilerplateLogger logger)
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
            AccountResponse productResult = await _accountService.GetAccountById(id);

            // Map our service-layer "ProductResult" DTO to our presentation "ProductResponse" DTO

            // Return our "ProductResponse"
            return Ok(productResult);
        }

        [HttpPost("add")]
        // [ProducesResponseType(StatusCodes.Status200OK)]
        // [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAccount([FromBody] AccountAdd accountAdd, IValidator<AccountAdd> validator)
        {
            if(!ModelState.IsValid){
                return BadRequest();
            }

            ValidationResult validationResult = await validator.ValidateAsync(accountAdd);

            if (!validationResult.IsValid)
            {
                // Log the validation errors
                _logger.LogInfo(String.Join(" ", validationResult.Errors));

                // Send validation errors back to the frontend for toast and such.
                List<string> validationErrors = new List<string>();
                validationResult.Errors.ForEach(f => validationErrors.Add(f.ErrorMessage));
                _statusService.AddStatus(StatusType.VALIDATION_ISSUE, validationErrors, StatusSeverity.ERROR);

                //return BadRequest(new JObject());
                return new EmptyResult();
            }

            AccountResponse p = await _accountService.AddAccount(accountAdd);

            return Ok(p);
        }
    }
}