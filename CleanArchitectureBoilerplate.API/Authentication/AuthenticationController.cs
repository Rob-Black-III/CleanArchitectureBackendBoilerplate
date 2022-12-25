using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitectureBoilerplate.API.APIResponseWrapper;
using CleanArchitectureBoilerplate.API.Authentication;
using CleanArchitectureBoilerplate.Application.Authentication;
using Microsoft.AspNetCore.Mvc;
using static CleanArchitectureBoilerplate.API.Authentication.AuthenticationPresentationDTOs;

namespace CleanArchitectureBoilerplate.API.Controllers;

    [ApiController]
    [Route("auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private IAPIResponseService _responseService;

        public AuthenticationController(IAuthenticationService authenticationService, IAPIResponseService responseService)
        {
            _responseService = responseService;
            _authenticationService = authenticationService;
        }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
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

        // MAP TO OUR API OBJECT
        _responseService.GetResponseObject().payload = Ok(response);

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
