using Inventory.Web.Services.ServiceInterface;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;
using Inventory.Web.ViewModels;

namespace Inventory.Web.Controllers
{
    public class SellsController : Controller
    {

        private readonly ISellProduct sellProductService;
        private readonly ICustomer customerServiec;
        private readonly IUnit unitService;
        private readonly ICategory categoryService;
        public SellsController(ISellProduct productService, ICustomer customerServiec, IUnit unitService, ICategory categoryService)
        {
            this.sellProductService = productService;
            this.customerServiec = customerServiec;
            this.unitService = unitService;
            this.categoryService = categoryService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetProductByProductCode(string ProductCode)
        {
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                WriteIndented = true
            };

            var product = await sellProductService.GetProductByProductCode(ProductCode);
            var result = JsonSerializer.Serialize(product, options);
            return new JsonResult(result);
        }
       
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            ViewBag.CustomerList =  await customerServiec.GetAllCustomersAsync();
            return View();
            
        }

        [HttpPost]
        public async Task<ActionResult> SaveSell([FromBody] SellBillViewModel invoiceBill)
        {
            
            return Ok("Sucess");

        }
    }
}
