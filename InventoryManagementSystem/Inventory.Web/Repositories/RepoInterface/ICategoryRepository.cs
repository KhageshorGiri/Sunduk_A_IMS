using Inventory.Entities.Entities;

namespace Inventory.Web.Repositories.RepoInterface
{
    public interface ICategoryRepository
    {
        Task CreateCategoryAsync(Category category);

        Task<IEnumerable<Category?>> GetAllCategoriesAsync();

        Task<Category?> GetCategoryAsync(int Id);

        Task UpdateCategoryAsync(Category exestingCategory);

        Task DeleteCategoryAsync(int Id);
    }
}
