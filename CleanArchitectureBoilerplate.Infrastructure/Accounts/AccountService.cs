using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitectureBoilerplate.Application.Accounts;
using CleanArchitectureBoilerplate.Application.Common.Services;
using CleanArchitectureBoilerplate.Application.Common.Status;
using CleanArchitectureBoilerplate.Domain.Entities;
using MapsterMapper;
using static CleanArchitectureBoilerplate.Application.Accounts.AccountDTO;

namespace CleanArchitectureBoilerplate.Infrastructure.Accounts
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ICleanArchitectureBoilerplateLogger _logger;
        private readonly ICleanArchitectureBoilerplateStatusService _statusService;
        private readonly IMapper _mapper;

        public AccountService(IAccountRepository accountRepository,
                              ICleanArchitectureBoilerplateStatusService statusService,
                              ICleanArchitectureBoilerplateLogger logger,
                              IMapper mapper)
        {
            _accountRepository = accountRepository;
            _statusService = statusService;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<AccountResponse> AddAccount(AccountAdd accountAdd)
        {
            Account a = _mapper.Map<Account>(accountAdd);
            Account accountAdded = await _accountRepository.AddAsync(a);
            return _mapper.Map<AccountResponse>(accountAdded);
        }

        public async Task<AccountResponse> GetAccountById(Guid id){
            return _mapper.Map<AccountResponse>(await _accountRepository.GetByIdAsync(id));
        }

        public AccountPlan GetAccountPlan(Guid id)
        {
            return default;
        }
    }
}