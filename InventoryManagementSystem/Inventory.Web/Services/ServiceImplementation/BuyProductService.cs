using Inventory.Entities.Entities;
using Inventory.Web.Services.ServiceInterface;
using Inventory.Web.ViewModels;

namespace Inventory.Web.Services.ServiceImplementation
{
    public class BuyProductService : IBuyProduct
    {
        public Task AddBuyBillAsync(BuyBillViewModel buyBillItems)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BuyBill?>> GetAllBuyBillsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BuyBill?> GetBuyBillAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateBuyBill(BuyBillViewModel buyBill)
        {
            throw new NotImplementedException();
        }
        
        public Task DeleteBuyBillAsync(int Id)
        {
            throw new NotImplementedException();
        }

    }
}
