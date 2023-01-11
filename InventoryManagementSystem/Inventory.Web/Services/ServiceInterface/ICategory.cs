using Inventory.Entities.Entities;

namespace Inventory.Web.Services.ServiceInterface
{
    public interface ICategory
    {
        Task CreateCategoryAsync(Category category);

        Task<IEnumerable<Category?>> GetAllCategoriesAsync();

        Task<Category?> GetCategoryAsync(int Id);

        Task UpdateCategoryAsync(int Id , Category existingCategory);

        Task DeleteCategoryAsync(int Id);

    }
}
