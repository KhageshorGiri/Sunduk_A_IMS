using Inventory.Web.ViewModels;

namespace Inventory.Web.Services.ServiceInterface
{
    public interface IStock
    {
        Task<IEnumerable<StockViewModel>> GetAllStockAsync();
    }
}
