using MoneyKeeper.Contracts.Requests;
using MoneyKeeper.Contracts.Responses;

namespace MoneyKeeper.Services.Transaction
{
    public interface ITransactionService
    {
        Task<TransactionResponse> CreateTransaction(TransactionCreateRequest request);
        Task<TransactionResponse> GetTransactionById(int id);
        Task<List<TransactionResponse>> GetTransactionByAccountId(int id);
        Task<TransactionResponse> UpdateTransaction(TransactionUpdateRequest request);
        Task MarkTransactionAsDeleted(int id);
    }
    //TODO: не добавлять транзакции с сервисными категориями(наверное проверка в контроллере, с фронта не может прийти сервисная категория) 
}
