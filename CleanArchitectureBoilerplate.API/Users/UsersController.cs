
using CleanArchitectureBoilerplate.API.Common.BaseController;
using CleanArchitectureBoilerplate.API.Common.BaseController.ActionResults;
using CleanArchitectureBoilerplate.Application.Accounts;
using CleanArchitectureBoilerplate.Application.Common.Services;
using CleanArchitectureBoilerplate.Application.Common.Validation;
using CleanArchitectureBoilerplate.Application.Users;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureBoilerplate.API.Accounts
{
    [Route("[controller]")]
    // Controller base gives us "OK() and BadRequest, 
    // wrappers around OkObjectResult and BadRequestResult, etc
    public class UsersController : CleanArchitectureBoilerplateController 
    {
        private readonly IUsersService _userService;
        private readonly ICleanArchitectureBoilerplateLogger _logger;

        public UsersController(IUsersService userService,
            ICleanArchitectureBoilerplateLogger logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(UserSingleDTO userUpdate)
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            Result<List<UserSingleDTO>> userSinglesAll = await _userService.GetAllUsers();
            return FromResult(userSinglesAll);
        }
    }
}