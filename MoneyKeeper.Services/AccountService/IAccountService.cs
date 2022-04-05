using MoneyKeeper.Contracts.Requests;
using MoneyKeeper.Contracts.Responses;

namespace Services.AccountService
{
    public interface IAccountService
    {
        Task<AccountResponse> CreateAccountAsync(AccountCreateRequest request);
        Task<AccountResponse> GetAccountByIdAsync(int id);
        Task<List<AccountResponse>> GetAccountsByUserIdAsync(int id);
        Task<AccountResponse> UpdateAccountAsync(AccountUpdateRequest request);
        Task MarkAccountAsDeletedAsync(int id);
    }
    //TODO: Не выводить IsDeleted, это везде
}
