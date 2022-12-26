
using Inventory.Entities.Entities;
using Inventory.Web.Services.ServiceInterface;

namespace Inventory.Web.Services.ServiceImplementation
{
    public class CategoryService : ICategory
    {
        private readonly ICategory _categoryService;
        public CategoryService(ICategory categoryService)
        {
            this._categoryService = categoryService;
        }

        public Task CreateCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category?>> GetAllCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Category?> GetCategoryAsync(int Id)
        {
            throw new NotImplementedException();
        }


        public Task UpdateCategoryAsync(Category exestingCategory)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCategoryAsync(int Id)
        {
            throw new NotImplementedException();
        }


    }
}
