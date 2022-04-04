using MoneyKeeper.Contracts.Requests;
using MoneyKeeper.Contracts.Responses;

namespace MoneyKeeper.Services.CategoryService
{
    public interface ICategoryService
    {
        #region Categories
        Task<CategoryResponse> CreateCategory(CategoryCreateRequest request);
        Task<CategoryResponse> GetCategoryById(int id);
        Task<List<CategoryResponse>> GetServiceCategoryByUserId(int id);
        Task<CategoryResponse> UpdateCategory(CategoryUpdateRequest request);
        Task MarkCategoryAsDeleted(int id);
        #endregion

        #region DefaultCategories
        Task<List<DefaultCategoryResponse>> GetAllDefaultCategories();
        #endregion

        //TODO: не отдавать фронту сервисные категории, сервисные категории нельзя редактировать (Initial Value), сервисные категории нельзя создавать обычным изерам
    }
}
