using CleanArchitectureBoilerplate.Application.Authentication;
using CleanArchitectureBoilerplate.Application.Common.Services;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using static CleanArchitectureBoilerplate.API.Authentication.AuthenticationPresentationDTOs;

namespace CleanArchitectureBoilerplate.API.Controllers
{
    [ApiController] // Decorator gives us 400 modelIsValid checks out of the box
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
        public IActionResult Register(RegisterRequest request, IValidator<RegisterRequest> validator)
        {
            _logger.LogDebug("Entering Register Controller...");

            ValidationResult validationResult = validator.Validate(request);

            if(!validationResult.IsValid) 
            {
                foreach (ValidationFailure failure in validationResult.Errors)
                {
                    _logger.LogKnownCritical(failure.ErrorMessage, true);
                }
                return BadRequest(new JObject());
            }


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

            _logger.LogDebug("Exiting Register Controller...");

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