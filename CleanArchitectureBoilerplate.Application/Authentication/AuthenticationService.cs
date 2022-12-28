using CleanArchitectureBoilerplate.Application.Common.Interfaces.Authentication;
using CleanArchitectureBoilerplate.Application.Common.Services;
using CleanArchitectureBoilerplate.Application.Common.Status;

namespace CleanArchitectureBoilerplate.Application.Authentication;

public class AuthenticationService : IAuthenticationService
{
    // DI Services
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly ICleanArchitectureBoilerplateStatusService _statusService;
    private readonly ICleanArchitectureBoilerplateLogger _logger;

    // DI Repository

    // It is important we separate the parameters and return types
    // from our incoming and outgoing API controller DTOS. For proper CA, versioning, etc.
    // Nothing from the API layer (including DTO's) should be referenced here.

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, 
    ICleanArchitectureBoilerplateLogger logger)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _logger = logger;
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        // Check if user already exists

        // Create user (generate unique ID)

        // Create JWT token
        Guid userId = Guid.NewGuid();

        var token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName);

        return new AuthenticationResult(
            userId,
            firstName,
            lastName,
            email,
            token);
    }

    public AuthenticationResult Login(string email, string password)
    {
        return new AuthenticationResult(
            Guid.NewGuid(),
            "firstName",
            "lastName",
            email,
            "token");
    }
}