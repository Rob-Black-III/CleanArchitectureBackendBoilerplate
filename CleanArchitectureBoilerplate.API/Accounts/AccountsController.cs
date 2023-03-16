using CleanArchitectureBoilerplate.API.Common.BaseController;
using CleanArchitectureBoilerplate.Application.Accounts;
using CleanArchitectureBoilerplate.Application.Common.Services;
using CleanArchitectureBoilerplate.Application.Common.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;
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
        private readonly ICleanArchitectureBoilerplateLogger _logger;

        public AccountsController(IAccountService accountService,
            ICleanArchitectureBoilerplateLogger logger)
        {
            _accountService = accountService;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([BindRequired] Guid id)
        {
            Result<AccountResponse> productResult = await _accountService.GetAccountById(id);
            return FromResult(productResult, HttpStatusCode.OK);
        }

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAccount([FromBody] AccountAdd accountAdd)
        {
            Result<AccountResponse> addAccountResult = await _accountService.AddAccount(accountAdd);
            return FromResult(addAccountResult, HttpStatusCode.Created);
        }
    }
}