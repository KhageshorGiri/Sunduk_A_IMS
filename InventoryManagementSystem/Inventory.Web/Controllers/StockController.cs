using Microsoft.AspNetCore.Mvc;

namespace Inventory.Web.Controllers
{
    public class StockController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
