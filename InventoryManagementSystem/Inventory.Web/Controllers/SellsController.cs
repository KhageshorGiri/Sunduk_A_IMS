using Inventory.Web.Services.ServiceInterface;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace Inventory.Web.Controllers
{
    public class SellsController : Controller
    {

        private readonly IBuyProduct buyProductService;
        private readonly ISupplier supplierServiec;
        private readonly IUnit unitService;
        private readonly ICategory categoryService;
        public SellsController(IBuyProduct productService, ISupplier supplierServiec, IUnit unitService, ICategory categoryService)
        {
            this.buyProductService = productService;
            this.supplierServiec = supplierServiec;
            this.unitService = unitService;
            this.categoryService = categoryService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.CustomerList =  supplierServiec.GetAllSuppliersAsync();
            return View();
        }
    }
}
