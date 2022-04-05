using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MoneyKeeper.Contracts.Requests;
using MoneyKeeper.Contracts.Responses;
using MoneyKeeper.Data.DB;
using MoneyKeeper.Data.DB.Tables;
using Services.AccountService;

namespace MoneyKeeper.Services.AccountService
{
    internal class AccountService : IAccountService
    {
        private readonly MoneyKeeperDB _context;
        private readonly IMapper _mapper;

        public AccountService(MoneyKeeperDB context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AccountResponse> CreateAccount(AccountCreateRequest request)
        {
            var account = _mapper.Map<Account>(request);
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<AccountResponse>(account);

            return result;
        }

        public async Task<AccountResponse> GetAccountById(int id)
        {
            var account = await _context.Accounts.SingleAsync(account => account.Id == id && !account.IsDeleted);
            var result = _mapper.Map<AccountResponse>(account);

            return result;
        }

        public async Task<List<AccountResponse>> GetAccountsByUserId(int id)
        {
            var accounts = _context.Accounts.Where(account => account.UserId == id && !account.IsDeleted);
            var result = await accounts.Select(account => _mapper.Map<AccountResponse>(account)).ToListAsync();

            return result;
        }

        public async Task MarkAccountAsDeleted(int id)
        {
            var account = await _context.Accounts.SingleAsync(account => account.Id == id);
            account.IsDeleted = true;
            _context.Update(account);
            await _context.SaveChangesAsync();
        }

        public async Task<AccountResponse> UpdateAccount(AccountUpdateRequest request)
        {
            var account = await _context.Accounts.SingleAsync(account => account.Id == request.Id);
            account.CurrencyId = request.CurrencyId;
            account.Name = request.Name;
            _context.Update(account);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<AccountResponse>(account);

            return result;
        }
    }
}
