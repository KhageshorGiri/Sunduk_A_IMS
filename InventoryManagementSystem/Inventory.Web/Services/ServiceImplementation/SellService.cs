using Inventory.Entities.Entities;
using Inventory.Web.Repositories.RepoInterface;
using Inventory.Web.Services.ServiceInterface;
using Inventory.Web.ViewModels;

namespace Inventory.Web.Services.ServiceImplementation
{
    public class SellService : ISellProduct
    {
        private readonly ISellRepository sellRepository;
        public SellService( ISellRepository sellRepo) 
        { 
            this.sellRepository = sellRepo;
        }

        public async Task AddSellBillAsync(SellBillViewModel buyBillItems)
        {
            await sellRepository.AddSellBillAsync(buyBillItems);
        }

        public Task DeleteSellBillAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Invoice?>> GetAllSellBillsAsync()
        {
            return await sellRepository.GetAllSellBillsAsync();
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
            var product = await sellRepository.GetProductByProductCode(productCode);
            return product; 
        }

    }
}
