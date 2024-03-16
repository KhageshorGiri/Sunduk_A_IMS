using Inventory.Web.Services.ServiceInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StockController : Controller
    {
        private readonly IStock _stockService;

        public StockController(IStock stockService)
        {
            _stockService = stockService;
        }

        public async Task<IActionResult> Index()
        {
            var stockDetails = await _stockService.GetAllStockAsync();
            return View(stockDetails);
        }
    }
}
