using CleanArchitectureBoilerplate.Domain.Common;

namespace CleanArchitectureBoilerplate.Domain.Entities
{
    public class Account : Entity, IAggregateRoot
    {
        public string Name {get; private set;} = null!;
        public Guid AccountPlanId { get; private set; }

        // public Account() { }

        // public Account(string name, Guid accountPlanId)
        // {
        //     Name = name;
        //     AccountPlanId = accountPlanId;
        // }
    }
    
}