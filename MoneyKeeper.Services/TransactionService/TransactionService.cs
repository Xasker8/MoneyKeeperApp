using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MoneyKeeper.Contracts.Requests;
using MoneyKeeper.Contracts.Responses;
using MoneyKeeper.Data.DB;
using MoneyKeeper.Data.DB.Tables;

namespace MoneyKeeper.Services.TransactionService
{
    public class TransactionService : ITransactionService
    {
        private readonly MoneyKeeperDB _context;
        private readonly IMapper _mapper;

        public TransactionService(MoneyKeeperDB context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TransactionResponse> CreateTransactionAsync(TransactionCreateRequest request)
        {
            var transaction = _mapper.Map<Transaction>(request);
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<TransactionResponse>(transaction);

            return result;
        }

        public async Task<TransactionResponse> GetTransactionByIdAsync(int id)
        {
            var transaction = await _context.Transactions.SingleAsync(transaction => transaction.Id == id && !transaction.IsDeleted);
            var result = _mapper.Map<TransactionResponse>(transaction);

            return result;
        }

        public async Task<List<TransactionResponse>> GetTransactionByAccountIdAsync(int id)
        {
            var transactions = _context.Transactions.Where(transaction => transaction.AccountId == id && !transaction.IsDeleted);
            var result = await transactions.Select(transaction => _mapper.Map<TransactionResponse>(transaction)).ToListAsync();

            return result;
        }

        public async Task<List<TransactionResponse>> GetTransactionByCategoryIdAsync(int id)
        {
            var transactions = _context.Transactions.Where(transaction => transaction.CategoryId == id && !transaction.IsDeleted);
            var result = await transactions.Select(transaction => _mapper.Map<TransactionResponse>(transaction)).ToListAsync();

            return result;
        }

        public async Task MarkTransactionAsDeletedAsync(int id)
        {
            var transaction = await _context.Transactions.SingleAsync(transaction => transaction.Id == id);
            transaction.IsDeleted = true;
            _context.Update(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task<TransactionResponse> UpdateTransactionAsync(TransactionUpdateRequest request)
        {
            var transaction = await _context.Transactions.SingleAsync(transaction => transaction.Id == request.Id && !transaction.IsDeleted);
            transaction.Sum = request.Sum;
            transaction.Comment = request.Comment;
            transaction.Date = request.Date;
            transaction.CategoryId = request.CategoryId;
            _context.Update(transaction);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<TransactionResponse>(transaction);

            return result;
        }
    }
}
