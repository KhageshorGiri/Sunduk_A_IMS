
using Inventory.Entities.Entities;
using Inventory.Web.Repositories.RepoInterface;

namespace Inventory.Web.Repositories.repoImplementation
{
    public class CategoryRepository : ICategoryRepository
    {
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
