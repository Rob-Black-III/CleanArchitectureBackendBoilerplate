using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitectureBoilerplate.Domain.Entities;
using Mapster;
using static CleanArchitectureBoilerplate.Application.Accounts.AccountDTO;

namespace CleanArchitectureBoilerplate.Application.Accounts
{
    public class AccountMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.ForType<AccountAdd, Account>().MapToConstructor(true);
            config.ForType<Account, AccountResponse>().MapToConstructor(true);
        }
    }
}