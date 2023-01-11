
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


        public async Task UpdateCategoryAsync(int id, Category category)
        {
            var exestingCategory = new Category()
            {
                CategoryId = id,
                CategoryName = category.CategoryName,
                Description = category.Description
            };
            await _categoryRepository.UpdateCategoryAsync(exestingCategory);
        }

        public async Task DeleteCategoryAsync(int Id)
        {
            var existingCategory = await _categoryRepository.GetCategoryAsync(Id);
            if(existingCategory != null)
            {
                await _categoryRepository.DeleteCategoryAsync(existingCategory);
            }           
        }


    }
}
