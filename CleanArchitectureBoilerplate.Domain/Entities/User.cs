using CleanArchitectureBoilerplate.Domain.SeedWork;

namespace CleanArchitectureBoilerplate.Domain.Entities
{
    public class User : IAggregateRoot
    {
        public Guid Id { get; set; } = default!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}