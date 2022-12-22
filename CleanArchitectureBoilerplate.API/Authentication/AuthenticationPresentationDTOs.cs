using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitectureBoilerplate.API.Authentication
{
    public class AuthenticationPresentationDTOs
    {
        public record AuthenticationResponse(Guid Id,
        string FirstName,
        string LastName,
        string Email,
        string Token);
    }

    public record LoginRequest(
    string Email,
    string Password);

    public record RegisterRequest(
    string FirstName,
    string LastName,
    string Email,
    string Password);
}