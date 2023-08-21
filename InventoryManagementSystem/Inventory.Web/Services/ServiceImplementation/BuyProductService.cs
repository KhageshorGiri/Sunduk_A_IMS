using Inventory.Entities.Entities;
using Inventory.Web.Repositories.RepoInterface;
using Inventory.Web.Services.ServiceInterface;
using Inventory.Web.ViewModels;

namespace Inventory.Web.Services.ServiceImplementation
{
    public class BuyProductService : IBuyProduct
    {
        private IBuyBillRepository buyBillRepository;

        public BuyProductService(IBuyBillRepository buyBillRepository)
        {
            this.buyBillRepository = buyBillRepository;
        }

        public async Task AddBuyBillAsync(BuyBillViewModel buyBillItems)
        {
            await buyBillRepository.AddBuyBillAsync(buyBillItems);
        }

        public async Task<IEnumerable<BuyBill?>> GetAllBuyBillsAsync()
        {
            return await buyBillRepository.GetAllBuyBillsAsync();
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
