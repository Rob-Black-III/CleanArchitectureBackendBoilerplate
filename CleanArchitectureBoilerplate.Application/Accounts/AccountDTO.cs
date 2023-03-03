namespace CleanArchitectureBoilerplate.Application.Accounts
{
    public class AccountDTO
    {
        public record AccountAdd{
            public required string Name { get; init; } = null!;
            // Do not use guid? will return guid.empty
            public Nullable<System.Guid> AccountPlanId { get; init; } = default!;
        }

        public record AccountResponse {
            public required Guid Id {get; init;}
            public required string Name { get; init; } = null!;
            public Nullable<System.Guid> AccountPlanId { get; init; }
        }
    }
}