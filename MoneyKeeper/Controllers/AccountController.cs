using Microsoft.AspNetCore.Mvc;
using MoneyKeeper.Contracts.Enums;
using MoneyKeeper.Contracts.Requests;
using MoneyKeeper.Contracts.Responses;
using MoneyKeeper.Services.CategoryService;
using MoneyKeeper.Services.Transaction;
using Services.AccountService;
using System.Net;

namespace MoneyKeeper.Controllers
{
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ITransactionService _transactionService;
        private readonly ICategoryService _categoryService;

        public AccountController(IAccountService accountService, ITransactionService transactionService, ICategoryService categoryService)
        {
            _accountService = accountService;
            _transactionService = transactionService;
            _categoryService = categoryService;
        }

        [HttpPost("CreateAccount")]
        public async Task<IActionResult> CreateAccount([FromBody] AccountCreateRequest request)
        {
            if (request is null)
            {
                return new StandardResponse<string>(HttpStatusCode.NotAcceptable, null, "Reqest is not provided or incorrect").Result;
            }
            //TODO: проверка на userId и currencyId

            var account = await _accountService.CreateAccount(request);
            var userCategories = await _categoryService.GetServiceCategoryByUserId(request.UserId);
            var initValueCategory = userCategories.Single(category => category.Name.Equals(DefaultCategoryEnum.InitialValue));
            await _transactionService.CreateTransaction(new TransactionCreateRequest
            {
                AccountId = account.Id,
                CategoryId = initValueCategory.Id,
                Comment = String.Empty,
                Date = request.Date,
                Sum = request.InitialValue
            });

            return new StandardResponse<AccountResponse>(HttpStatusCode.OK, account, "Success").Result;
        }

        [HttpGet("Account/{id}")]
        public async Task<IActionResult> GetAccountById(int id)
        {
            var account = await _accountService.GetAccountById(id);

            return new StandardResponse<AccountResponse>(HttpStatusCode.OK, account, "Success").Result;

        }

        [HttpPost("UpdateAccount")]
        public async Task<IActionResult> UpdateAccount([FromBody] AccountUpdateRequest request)
        {
            if (request is null)
            {
                return new StandardResponse<string>(HttpStatusCode.NotAcceptable, null, "Reqest is not provided or incorrect").Result;
            }
            //TODO: Проверка на CurrencyId
            var account = await _accountService.UpdateAccount(request);

            return new StandardResponse<AccountResponse>(HttpStatusCode.OK, account, "Success").Result;
        }

        [HttpDelete("Account/{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            var transactions = await _transactionService.GetTransactionByAccountId(id);
            foreach(var transactionId in transactions.Select(transaction => transaction.Id))
            {
                await _transactionService.MarkTransactionAsDeleted(transactionId);
            }

            await _accountService.MarkAccountAsDeleted(id);

            return new StandardResponse<bool>(HttpStatusCode.OK, true, "Success").Result;
        }
    }
}
