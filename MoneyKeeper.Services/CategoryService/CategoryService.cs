using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MoneyKeeper.Contracts.Enums;
using MoneyKeeper.Contracts.Requests;
using MoneyKeeper.Contracts.Responses;
using MoneyKeeper.Data.DB;
using MoneyKeeper.Data.DB.Tables;

namespace MoneyKeeper.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly MoneyKeeperDB _context;
        private readonly IMapper _mapper;

        public CategoryService(MoneyKeeperDB context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #region Categories
        public async Task<CategoryResponse> CreateCategoryAsync(CategoryCreateRequest request)
        {
            if(!await IsCategoryUnique(request.Name, request.Type))
            {
                //TODO:Error
            }

            var category = _mapper.Map<Category>(request);
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<CategoryResponse>(category);

            return result;
        }

        public async Task<CategoryResponse> GetCategoryByIdAsync(int id)
        {
            var category = await _context.Categories.SingleAsync(category => category.Id == id && !category.IsDeleted);
            var result = _mapper.Map<CategoryResponse>(category);

            return result;
        }

        public async Task<List<CategoryResponse>> GetServiceCategoriesByUserIdAsync(int id)
        {
            var categories = _context.Categories.Where(category => category.Type == (int)CategoryTypeEnum.Service && category.UserId == id && !category.IsDeleted);
            var result = await categories.Select(category => _mapper.Map<CategoryResponse>(category)).ToListAsync();

            return result;
        }

        public async Task<CategoryResponse> UpdateCategoryAsync(CategoryUpdateRequest request)
        {
            if (!await IsCategoryUnique(request.Name, request.Type))
            {
                //TODO:Error
            }

            var category = await _context.Categories.SingleAsync(category => category.Id == request.Id && !category.IsDeleted);
            category.Name = request.Name;
            category.Type = request.Type;
            _context.Update(category);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<CategoryResponse>(category);

            return result;
        }

        public async Task MarkCategoryAsDeletedAsync(int id)
        {
            var category = await _context.Categories.SingleAsync(category => category.Id == id);
            category.IsDeleted = true;
            _context.Update(category);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region DefaultCategories
        public async Task<List<DefaultCategoryResponse>> GetAllDefaultCategoriesAsync()
        {
            var defaultCategories = await _context.DefaultCategories.ToListAsync();
            var result = defaultCategories.Select(defaultCategory => _mapper.Map<DefaultCategoryResponse>(defaultCategory)).ToList();

            return result;
        }
        #endregion

        private async Task<bool> IsCategoryUnique(string name, int type)
        {
            var categories = await _context.Categories.Where(category => category.Name.Equals(name) && category.Type == type && !category.IsDeleted).ToListAsync();

            return !categories.Any();
        }
    }
}
