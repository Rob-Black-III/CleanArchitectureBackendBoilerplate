namespace CleanArchitectureBoilerplate.Application.Accounts
{
    public class AccountDTO
    {
        public record AccountAdd{
            public string Name { get; init; } = null!;
            public Guid? AccountPlanId { get; init; }
        }

        public record AccountResponse {
            public Guid Id {get; init;}
            public string Name { get; init; } = null!;
            public Guid? AccountPlanId { get; init; }
        }
    }
}