using MoneyKeeper.Contracts.Requests;
using MoneyKeeper.Contracts.Responses;

namespace MoneyKeeper.Services.TransactionService
{
    public interface ITransactionService
    {
        Task<TransactionResponse> CreateTransactionAsync(TransactionCreateRequest request);
        Task<TransactionResponse> GetTransactionByIdAsync(int id);
        Task<List<TransactionResponse>> GetTransactionByAccountIdAsync(int id);
        Task<List<TransactionResponse>> GetTransactionByCategoryIdAsync(int id);
        Task<TransactionResponse> UpdateTransactionAsync(TransactionUpdateRequest request);
        Task MarkTransactionAsDeletedAsync(int id);
    }
    //TODO: не добавлять транзакции с сервисными категориями(наверное проверка в контроллере, с фронта не может прийти сервисная категория) 
}
