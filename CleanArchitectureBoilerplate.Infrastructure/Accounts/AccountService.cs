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

        // The application service layer is generally used for coordination rather than implementation. 
        // Here we just want to do * only * the neccesary steps to dispatch to our infrastructure layer
        // TODO check for mapping issues here?

        // For Error Handling
        // "Business" Errors should be checked and handled in the application / dispatch / coordination layer (interchangable names)
        // "Technology" Errors should be handled in the "closest" layer to the problem 
        //      (db connection errors in infrastructure, http issues in presentation, mapping issues in application layer)
        // https://levelup.gitconnected.com/error-handling-in-clean-architecture-9ff159a25d4a
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