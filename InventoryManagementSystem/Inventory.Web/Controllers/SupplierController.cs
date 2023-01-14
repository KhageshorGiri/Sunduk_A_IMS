using Inventory.Web.Services.ServiceInterface;
using Inventory.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Web.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplier supplierService;

        public SupplierController(ISupplier supplierServ)
        {
            this.supplierService = supplierServ;
        }


        // GET: Supplier
        public async Task<ActionResult> Index()
        {
            var allSuppliersDetails = await supplierService.GetAllSuppliersAsync();
            return View(allSuppliersDetails);
        }

        // GET: Supplier/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Supplier/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Supplier/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind] SupplierCustomerEmployeeViewModel supplier)
        {
            try
            {
                await supplierService.CreateSupplierAsync(supplier);
                return RedirectToAction("Create");
            }
            catch
            {
                return View();
            }
        }

        // GET: Supplier/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Supplier/Edit/5
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

        // GET: Supplier/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Supplier/Delete/5
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
