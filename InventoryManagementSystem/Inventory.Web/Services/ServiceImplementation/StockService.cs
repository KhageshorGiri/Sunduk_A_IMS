using Inventory.Web.Repositories.RepoInterface;
using Inventory.Web.Services.ServiceInterface;
using Inventory.Web.ViewModels;

namespace Inventory.Web.Services.ServiceImplementation
{
    public class StockService : IStock
    {
        private readonly IStockRepository _stockRepository;

        public StockService(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task<IEnumerable<StockViewModel>> GetAllStockAsync()
        {
            return await _stockRepository.GetAllStockAsync();
        }
    }
}
