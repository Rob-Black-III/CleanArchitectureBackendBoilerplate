using CleanArchitectureBoilerplate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitectureBoilerplate.Infrastructure.Accounts
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(b => b.AccountPlanId).IsRequired();

            builder.Property(b => b.Name).IsRequired();
        }
    }
}