using CleanArchitectureBoilerplate.Application.Authentication;
using CleanArchitectureBoilerplate.Application.Common.Services;
using CleanArchitectureBoilerplate.Application.Common.Status;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using Newtonsoft.Json.Linq;
using static CleanArchitectureBoilerplate.API.Authentication.AuthenticationPresentationDTOs;

namespace CleanArchitectureBoilerplate.API.Controllers
{
    [ApiController] // Decorator gives us 400 modelIsValid checks out of the box
    [Route("auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ICleanArchitectureBoilerplateStatusService _statusService;
        private readonly ICleanArchitectureBoilerplateLogger _logger;

        public AuthenticationController(IAuthenticationService authenticationService, ICleanArchitectureBoilerplateStatusService statusService, ICleanArchitectureBoilerplateLogger logger)
        {
            _authenticationService = authenticationService;
            _statusService = statusService;
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request, IValidator<RegisterRequest> validator)
        {
            _logger.LogDebug("Entering Register Controller...");

            ValidationResult validationResult = await validator.ValidateAsync(request);

            if(!validationResult.IsValid) 
            {
                // foreach (ValidationFailure failure in validationResult.Errors)
                // {
                //     _logger.LogKnownCritical(failure.ErrorMessage);
                // }

                // Log the validation errors
                _logger.LogInfo(String.Join(" ", validationResult.Errors));

                // Send validation errors back to the frontend for toast and such.
                List<string> validationErrors = new List<string>();
                validationResult.Errors.ForEach(f => validationErrors.Add(f.ErrorMessage));
                _statusService.AddStatus(StatusType.VALIDATION_ISSUE, validationErrors, StatusSeverity.ERROR);

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