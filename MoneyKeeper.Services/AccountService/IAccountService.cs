using MoneyKeeper.Contracts.Requests;
using MoneyKeeper.Contracts.Responses;

namespace Services.AccountService
{
    public interface IAccountService
    {
        Task<AccountResponse> CreateAccount(AccountCreateRequest request);
        Task<AccountResponse> GetAccountById(int id);
        Task<List<AccountResponse>> GetAccountsByUserId(int id);
        Task<AccountResponse> UpdateAccount(AccountUpdateRequest request);
        Task MarkAccountAsDeleted(int id);
    }
    //TODO: Не выводить IsDeleted, это везде
}
