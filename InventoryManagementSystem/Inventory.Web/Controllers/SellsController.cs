using Inventory.Web.Services.ServiceInterface;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace Inventory.Web.Controllers
{
    public class SellsController : Controller
    {

        private readonly IBuyProduct buyProductService;
        private readonly ICustomer customerServiec;
        private readonly IUnit unitService;
        private readonly ICategory categoryService;
        public SellsController(IBuyProduct productService, ICustomer customerServiec, IUnit unitService, ICategory categoryService)
        {
            this.buyProductService = productService;
            this.customerServiec = customerServiec;
            this.unitService = unitService;
            this.categoryService = categoryService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetProductByProductCode(string ProductCode)
        {
            return View();
        }
       
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            ViewBag.CustomerList =  await customerServiec.GetAllCustomersAsync();
            return View();
        }
    }
}
