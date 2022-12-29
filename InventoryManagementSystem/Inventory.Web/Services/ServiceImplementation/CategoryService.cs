
using Inventory.Entities.Entities;
using Inventory.Web.Repositories.RepoInterface;
using Inventory.Web.Services.ServiceInterface;

namespace Inventory.Web.Services.ServiceImplementation
{
    public class CategoryService : ICategory
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }

        public async Task CreateCategoryAsync(Category category)
        {
            await _categoryRepository.CreateCategoryAsync(category);
        }

        public async Task<IEnumerable<Category?>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();
            return categories;
        }

        public async Task<Category?> GetCategoryAsync(int Id)
        {
            var category = await _categoryRepository.GetCategoryAsync(Id);
            return category;
        }


        public async Task UpdateCategoryAsync(Category exestingCategory)
        {
            await _categoryRepository.UpdateCategoryAsync(exestingCategory);
        }

        public async Task DeleteCategoryAsync(int Id)
        {
            await _categoryRepository.DeleteCategoryAsync(Id);
        }


    }
}
