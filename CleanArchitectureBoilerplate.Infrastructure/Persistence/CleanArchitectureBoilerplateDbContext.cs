using System.Reflection;
using Microsoft.EntityFrameworkCore;
using CleanArchitectureBoilerplate.Domain.Entities;

namespace CleanArchitectureBoilerplate.Infrastructure.Persistence
{
    public class CleanArchitectureBoilerplateDbContext : DbContext
    {
        public CleanArchitectureBoilerplateDbContext(DbContextOptions options) : base(options)
        {
        }

        // The "Product" would be stored in the domain layer, but our Infrastructure layer (this)
        // does not reference the domain layer.
        // 

        public DbSet<Product> Products { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}