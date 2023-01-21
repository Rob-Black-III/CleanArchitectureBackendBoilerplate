using System.Reflection;
using Microsoft.EntityFrameworkCore;
using CleanArchitectureBoilerplate.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace CleanArchitectureBoilerplate.Infrastructure.Persistence
{
    public class CleanArchitectureBoilerplateDbContext : DbContext
    {
        protected readonly IConfiguration _configuration;
        public CleanArchitectureBoilerplateDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("WebApiDatabase"));
        }
    }
}