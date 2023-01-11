
using Inventory.Entities.Entities;
using Inventory.Web.Data;
using Inventory.Web.Repositories.RepoInterface;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Web.Repositories.repoImplementation
{
    public class CategoryRepository : ICategoryRepository
    {
        string configuration = new ConfigurationManager().GetConnectionString("DataBaseConnection");

        private readonly InventorySystemDbContext dbContext;
        public CategoryRepository(InventorySystemDbContext context)
        {
            this.dbContext = context;
        }
        public async Task CreateCategoryAsync(Category category)
        {
            dbContext.Categories.Add(category);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category?>> GetAllCategoriesAsync()
        {
            var categoryList = dbContext.Categories;
            return await categoryList.ToListAsync();
        }

        public async Task<Category?> GetCategoryAsync(int Id)
        {
            var category = await dbContext.Categories.FindAsync(Id);
            return category;
        }


        public async Task UpdateCategoryAsync(Category exestingCategory)
        {
            dbContext.Categories.Update(exestingCategory);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(Category exestingCategory)
        {
            dbContext.Categories.Remove(exestingCategory);
            await dbContext.SaveChangesAsync();
        }
    }
}
