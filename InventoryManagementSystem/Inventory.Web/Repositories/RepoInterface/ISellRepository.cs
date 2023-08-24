using Inventory.Entities.Entities;
using Inventory.Web.ViewModels;

namespace Inventory.Web.Repositories.RepoInterface
{
    public interface ISellRepository
    {
        //CRUD

        Task AddSellBillAsync(SellBillViewModel buyBillItems);

        Task<IEnumerable<Invoice?>> GetAllSellBillsAsync();

        Task<Invoice?> GetSellBillAsync();

        Task UpdateSellBill(SellBillViewModel buyBill);

        Task DeleteSellBillAsync(int Id);

        // additional services
        Task<Product?> GetProductByProductCode(string productCode);
    }
}
