using Inventory.Entities.Entities;
using Inventory.Web.Services.ServiceInterface;
using Inventory.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Inventory.Web.Controllers
{
    public class ProductController : Controller
    {

        private readonly IBuyProduct buyProductService;
        private readonly ISupplier supplierServiec;
        private readonly IUnit unitService;
        private readonly ICategory categoryService;
        public ProductController(IBuyProduct productService, ISupplier supplierServiec, IUnit unitService, ICategory categoryService)
        {
            this.buyProductService = productService;
            this.supplierServiec = supplierServiec;
            this.unitService = unitService;
            this.categoryService = categoryService;
        }


        // GET: ProductController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.SupplierList = await supplierServiec.GetAllSuppliersAsync();
            var unitDetails = await unitService.GetAllUnitsAsync();
            var categoryDetails = await categoryService.GetAllCategoriesAsync();

            ViewBag.UnitList = new SelectList(unitDetails.ToList(), "UnitId", "ShortForm");
            ViewBag.CategoryList = new SelectList(categoryDetails.ToList(), "CategoryId", "CategoryName");

            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddProducts([FromBody] BuyBillViewModel buyBill)//int SupplierId, string BillNumber, string VoucherDate, string PurchaseDate,
            //string IssuedDate, string Comment, Product[] ProductsList)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await buyProductService.AddBuyBillAsync(buyBill);
                }
                return RedirectToAction(nameof(Create));
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
