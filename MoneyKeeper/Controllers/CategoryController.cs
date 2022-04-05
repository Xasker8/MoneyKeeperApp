using Microsoft.AspNetCore.Mvc;
using MoneyKeeper.Contracts.Enums;
using MoneyKeeper.Contracts.Requests;
using MoneyKeeper.Contracts.Responses;
using MoneyKeeper.Services.CategoryService;
using MoneyKeeper.Services.TransactionService;
using System.Net;

namespace MoneyKeeper.Controllers
{
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly ITransactionService _transactionService;

        public CategoryController(ICategoryService categoryService, ITransactionService transactionService)
        {
            _categoryService = categoryService;
            _transactionService = transactionService;

        }

        [HttpPost("Category")]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryCreateRequest request)
        {
            if (request is null)
            {
                return new StandardResponse<string>(HttpStatusCode.NotAcceptable, null, "Reqest is not provided or incorrect").Result;
            }

            if (request.Type == (int)CategoryTypeEnum.Service)
            {
                return new StandardResponse<string>(HttpStatusCode.NotAcceptable, null, "Incorrect category type").Result;
            }

            var category = await _categoryService.CreateCategoryAsync(request);

            return new StandardResponse<CategoryResponse>(HttpStatusCode.OK, category, "Success").Result;
        }

        [HttpGet("Category/{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);

            //TODO: пооверка на id?
            return new StandardResponse<CategoryResponse>(HttpStatusCode.OK, category, "Success").Result;
        }

        [HttpPost("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory([FromBody] CategoryUpdateRequest request)
        {
            if (request is null)
            {
                return new StandardResponse<string>(HttpStatusCode.NotAcceptable, null, "Reqest is not provided or incorrect").Result;
            }

            if (request.Type == (int)CategoryTypeEnum.Service)
            {
                return new StandardResponse<string>(HttpStatusCode.NotAcceptable, null, "Incorrect category type").Result;
            }

            var category = await _categoryService.GetCategoryByIdAsync(request.Id);
            if (category.Type == (int)CategoryTypeEnum.Service)
            {
                return new StandardResponse<string>(HttpStatusCode.NotAcceptable, null, $"Can't update category").Result;
            }

            //TODO: Проверка на CurrencyId
            var cateory = await _categoryService.UpdateCategoryAsync(request);

            return new StandardResponse<CategoryResponse>(HttpStatusCode.OK, cateory, "Success").Result;
        }

        [HttpDelete("Category/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category.Type == (int)CategoryTypeEnum.Service)
            {
                return new StandardResponse<string>(HttpStatusCode.NotAcceptable, null, $"Can't delete category").Result;
            }

            var transactions = await _transactionService.GetTransactionByCategoryIdAsync(id);
            foreach (var transactionId in transactions.Select(transaction => transaction.Id))
            {
                await _transactionService.MarkTransactionAsDeletedAsync(transactionId);
            }
            //TODO: пооверка на id?
            await _categoryService.MarkCategoryAsDeletedAsync(id);

            return new StandardResponse<bool>(HttpStatusCode.OK, true, "Success").Result;
        }
    }
}
