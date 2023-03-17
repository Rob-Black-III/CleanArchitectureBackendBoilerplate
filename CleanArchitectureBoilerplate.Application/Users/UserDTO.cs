namespace CleanArchitectureBoilerplate.Application.Accounts
{
    // 'required' keyword effectively allows us to not use constructors,
    // while still requiring certain fields be used when instantiated
    public record UserSingleDTO
    {
        public Guid Id { get; init; } = default!; // Guid is not nullable, it can be set to default, we want to assure it is not.
        public string FirstName { get; init; } = null!;
        public string LastName { get; init; } = null!;
        public string Email { get; init; } = null!;
        public string Username { get; init; } = null!;
        public string Role { get; init; } = null!;
    }
    public record UserRegisterDTO
    {
        public string FirstName { get; init; } = null!;
        public string LastName { get; init; } = null!;
        public string Email { get; init; } = null!;
        public string Username { get; init; } = null!;
        public string Password { get; init; } = null!;
    }

    public record AuthenticateRequestDTO
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}