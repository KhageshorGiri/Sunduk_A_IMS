using Inventory.Web.Services.ServiceInterface;
using Inventory.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Inventory.Web.Controllers
{
    [Authorize(Roles = "Admin")]
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
        public async Task<ActionResult> Index()
        {
            var productDetails =  await buyProductService.GetAllBuyBillsAsync();
            return View(productDetails);
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
        public async Task<ActionResult> AddProducts([FromBody] BuyBillViewModel buyBillView)
        { 
            try
            {
                await buyProductService.AddBuyBillAsync(buyBillView);
                TempData["Success"] = "Create Sucess";
                return Json(new { Success=true, Message = TempData["Success"] });
            }
            catch(Exception ex)
            {
                TempData["Error"] = "Create Error";
                return Json(new { Success = false, Message = TempData["Error"] });
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
