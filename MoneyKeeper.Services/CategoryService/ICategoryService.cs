using MoneyKeeper.Contracts.Requests;
using MoneyKeeper.Contracts.Responses;

namespace MoneyKeeper.Services.CategoryService
{
    public interface ICategoryService
    {
        #region Categories
        Task<CategoryResponse> CreateCategoryAsync(CategoryCreateRequest request);
        Task<CategoryResponse> GetCategoryByIdAsync(int id);
        Task<List<CategoryResponse>> GetServiceCategoriesByUserIdAsync(int id);
        Task<CategoryResponse> UpdateCategoryAsync(CategoryUpdateRequest request);
        Task MarkCategoryAsDeletedAsync(int id);
        #endregion

        #region DefaultCategories
        Task<List<DefaultCategoryResponse>> GetAllDefaultCategoriesAsync();
        #endregion

        //TODO: не отдавать фронту сервисные категории, сервисные категории нельзя редактировать (Initial Value), сервисные категории нельзя создавать обычным изерам
    }
}
