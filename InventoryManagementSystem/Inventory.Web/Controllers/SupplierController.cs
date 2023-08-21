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
        public async Task<ActionResult> Details(int id)
        {
            var supplier = await supplierService.GetSupplierAsync(id);
            if(supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }

        // GET: Supplier/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Supplier/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind (include: "SupplierName, PhoneNumber, Email, PanNumber, Country, City, LocalAddress")] SupplierViewModel supplier)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await supplierService.CreateSupplierAsync(supplier);
                    return RedirectToAction("Create");
                }
                return View(supplier);
            }
            catch
            {
                return View();
            }
        }

        // GET: Supplier/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var supplier = await supplierService.GetSupplierAsync(id);
            if (supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }

        // POST: Supplier/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind] SupplierViewModel existingSupplier)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await supplierService.UpddateSupplierAsync(existingSupplier);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
