namespace CleanArchitectureBoilerplate.Application.Accounts
{
    public class AccountDTO
    {
        public record AccountAdd{
            public required string Name { get; init; } = null!;
            public Guid? AccountPlanId { get; init; }
        }

        public record AccountResponse {
            public required Guid Id {get; init;}
            public required string Name { get; init; } = null!;
            public Guid? AccountPlanId { get; init; }
        }
    }
}