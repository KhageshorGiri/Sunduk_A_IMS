
using Inventory.Web.ViewModels;

namespace Inventory.Web.Repositories.RepoInterface
{
    public interface IStockRepository
    {
        Task<IEnumerable<StockViewModel>> GetAllStockAsync();
    }
}
