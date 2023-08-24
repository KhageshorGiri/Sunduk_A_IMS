using Inventory.Entities.Entities;
using Inventory.Web.Data;
using Inventory.Web.Repositories.RepoInterface;
using Inventory.Web.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Web.Repositories.repoImplementation
{
    public class SellRepository : ISellRepository
    {
        private readonly InventorySystemDbContext _dbContext;
        public SellRepository(InventorySystemDbContext context)
        { 
            this._dbContext = context;
        }
        public Task AddSellBillAsync(SellBillViewModel buyBillItems)
        {
            throw new NotImplementedException();
        }

        public Task DeleteSellBillAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Invoice?>> GetAllSellBillsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Invoice?> GetSellBillAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateSellBill(SellBillViewModel buyBill)
        {
            throw new NotImplementedException();
        }

        public async Task<Product?> GetProductByProductCode(string productCode)
        {
            var product = await _dbContext.Products
                .Include(x => x.Category)
                .Include(x => x.Unit)
                .FirstOrDefaultAsync(x => x.ProductCode == productCode);
            return  product;
        }

    }
}
