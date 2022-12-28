using CleanArchitectureBoilerplate.API.Authentication;
using CleanArchitectureBoilerplate.Application.Authentication;
using CleanArchitectureBoilerplate.Application.Common.Services;
using Microsoft.AspNetCore.Mvc;
using static CleanArchitectureBoilerplate.API.Authentication.AuthenticationPresentationDTOs;

namespace CleanArchitectureBoilerplate.API.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ICleanArchitectureBoilerplateLogger _logger;

        public AuthenticationController(IAuthenticationService authenticationService, ICleanArchitectureBoilerplateLogger logger)
        {
            _authenticationService = authenticationService;
            _logger = logger;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            _logger.LogDebug("Entering Register Controller...", false);

            var authResult = _authenticationService.Register(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password);

            var response = new AuthenticationResponse(
                authResult.Id,
                authResult.FirstName,
                authResult.LastName,
                authResult.Email,
                authResult.Token);

            _logger.LogDebug("Exiting Register Controller...", false);

            return Ok(response);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var authResult = _authenticationService.Login(
                request.Email,
                request.Password);

            var response = new AuthenticationResponse(
                authResult.Id,
                authResult.FirstName,
                authResult.LastName,
                authResult.Email,
                authResult.Token);

            return Ok(response);
        }
    }
}