using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CleanArchitectureBoilerplate.Application.Accounts;
using CleanArchitectureBoilerplate.Application.Common.Interfaces.Persistence;
using CleanArchitectureBoilerplate.Domain.Entities;
using CleanArchitectureBoilerplate.Infrastructure.Persistence;

namespace CleanArchitectureBoilerplate.Infrastructure.Accounts
{
    internal class AccountRepository : EFRepository<Account>, IAccountRepository
    {
        public AccountRepository(CleanArchitectureBoilerplateDbContext dbContext) : base(dbContext)
        {
        }
    }
}