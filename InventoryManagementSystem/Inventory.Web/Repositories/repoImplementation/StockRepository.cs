using Inventory.Web.Data;
using Inventory.Web.Repositories.RepoInterface;
using Inventory.Web.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Web.Repositories.repoImplementation
{
    public class StockRepository : IStockRepository
    {

        private readonly InventorySystemDbContext _dbContext;

        public StockRepository(InventorySystemDbContext context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<StockViewModel>> GetAllStockAsync()
        {
            var Query = from product in _dbContext.Products
                        join buyBill in _dbContext.BuyBills on product.BillId equals buyBill.BillId
                        select new StockViewModel
                        {
                            ProductId = product.ProductId,
                            ProductCode = product.ProductCode,
                            ProductName =product.ProductName,
                            Quantity = product.Quantity,
                            SoldQuantity = product.SoldQuantity,
                            PurchaseDate = buyBill.PurchaseDate
                        };

            return await Query
                .AsNoTracking()
                .ToListAsync();

        }

    }
}
