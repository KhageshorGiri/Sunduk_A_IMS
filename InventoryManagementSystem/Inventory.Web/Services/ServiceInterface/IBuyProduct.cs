using Inventory.Entities.Entities;
using Inventory.Web.ViewModels;

namespace Inventory.Web.Services.ServiceInterface
{
    public interface IBuyProduct
    {
        //CRUD

        Task AddBuyBillAsync(BuyBillViewModel buyBillItems);

        Task<IEnumerable<BuyBill?>> GetAllBuyBillsAsync();

        Task<BuyBill?> GetBuyBillAsync();

        Task UpdateBuyBill(BuyBillViewModel buyBill);

        Task DeleteBuyBillAsync(int Id);
    }
}
