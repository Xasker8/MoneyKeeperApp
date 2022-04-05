using Microsoft.AspNetCore.Mvc;
using MoneyKeeper.Contracts.Enums;
using MoneyKeeper.Contracts.Requests;
using MoneyKeeper.Contracts.Responses;
using MoneyKeeper.Services.CategoryService;
using MoneyKeeper.Services.TransactionService;
using System.Net;

namespace MoneyKeeper.Controllers
{
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly ICategoryService _categoryService;

        public TransactionController(ITransactionService transactionService, ICategoryService categoryService)
        {
            _transactionService = transactionService;
            _categoryService = categoryService;
        }

        [HttpPost("Transaction")]
        public async Task<IActionResult> CreateTransactoin([FromBody] TransactionCreateRequest request)
        {
            if(request is null)
            {
                return new StandardResponse<string>(HttpStatusCode.NotAcceptable, null, "Reqest is not provided or incorrect").Result;
            }

            var category = await _categoryService.GetCategoryByIdAsync(request.CategoryId);
            if(category.Type == (int)CategoryTypeEnum.Service)
            {
                return new StandardResponse<string>(HttpStatusCode.NotAcceptable, null, "Incorrect category").Result;
            }

            var transaction = await _transactionService.CreateTransactionAsync(request);

            return new StandardResponse<TransactionResponse>(HttpStatusCode.OK, transaction, "Success").Result;
        }

        [HttpGet("Transaction/{id}")]
        public async Task<IActionResult> GetTransactoinById(int id)
        {
            var transaction = await _transactionService.GetTransactionByIdAsync(id);

            return new StandardResponse<TransactionResponse>(HttpStatusCode.OK, transaction, "Success").Result;
        }

        [HttpGet("AccountTransactions/{id}")]
        public async Task<IActionResult> GetTransactoinsByAccountId(int id)
        {
            var transactions = await _transactionService.GetTransactionByAccountIdAsync(id);

            return new StandardResponse<List<TransactionResponse>>(HttpStatusCode.OK, transactions, "Success").Result;
        }

        [HttpPost("UpdateTransaction")]
        public async Task<IActionResult> UpdateTransaction([FromBody] TransactionUpdateRequest request)
        {
            if (request is null)
            {
                return new StandardResponse<string>(HttpStatusCode.NotAcceptable, null, "Reqest is not provided or incorrect").Result;
            }
            var oldTransaction = await _transactionService.GetTransactionByIdAsync(request.Id);
            var oldCategory = await _categoryService.GetCategoryByIdAsync(oldTransaction.CategoryId);
            var category = await _categoryService.GetCategoryByIdAsync(request.CategoryId);
            if (category.Type != oldCategory.Type && category.Type == (int)CategoryTypeEnum.Service)
            {
                return new StandardResponse<string>(HttpStatusCode.NotAcceptable, null, "Incorrect category").Result;
            }
            //TODO: Проверка на CurrencyId
            var transaction = await _transactionService.UpdateTransactionAsync(request);

            return new StandardResponse<TransactionResponse>(HttpStatusCode.OK, transaction, "Success").Result;
        }

        [HttpDelete("Transaction/{id}")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            await _transactionService.MarkTransactionAsDeletedAsync(id);

            return new StandardResponse<bool>(HttpStatusCode.OK, true, "Success").Result;
        }
    }
}
