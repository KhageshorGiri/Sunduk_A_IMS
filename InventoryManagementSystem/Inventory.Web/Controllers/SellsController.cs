using Inventory.Web.Services.ServiceInterface;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;
using Inventory.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Inventory.Web.Controllers
{
    [Authorize(Roles = "Admin")]
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

        public async Task<IActionResult> Index()
        {
            var sellInvocieDetails = await sellProductService.GetAllSellBillsAsync();
            return View(sellInvocieDetails);
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
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SaveSell([FromBody] SellBillViewModel invoiceBill)//(int? CustomerID, string BillNumber, string VoucherDate, string BillIssueDate, string Comment, SellProductList[] Products)
        {
            try
            {
                await sellProductService.AddSellBillAsync(invoiceBill);

                return Ok("Sucess");
            }
            catch (Exception ex)
            {
                string mgs = ex.Message;
                throw;
            }

        }
    }
}
