using CleanArchitectureBoilerplate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitectureBoilerplate.Infrastructure.Users
{
    public class UsersConfiguration : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Username).IsRequired();
            builder.Property(b => b.Email).IsRequired();
            builder.Property(b => b.Password).IsRequired();
        }
    }
}