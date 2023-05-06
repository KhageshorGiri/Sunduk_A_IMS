using Inventory.Web.Services.ServiceImplementation;
using Inventory.Web.Services.ServiceInterface;
using Inventory.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Web.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomer customerService;

        public CustomersController(ICustomer customerServ)
        {
            this.customerService = customerServ;
        }


        // GET: Customer
        public async Task<IActionResult> IndexAsync()
        {
            var allCustomersDetails = await customerService.GetAllCustomersAsync();
            return View(allCustomersDetails);
        }


        // GET: Customer/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var supplier = await customerService.GetCustomerAsync(id);
            if (supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }

        // GET: Customer/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind] SupplierCustomerEmployeeViewModel customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await customerService.CreateCustomerAsync(customer);
                    return RedirectToAction("Create");
                }
                return View(customer);
            }
            catch
            {
                return View();
            }
        }

       // GET: Customer/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var supplier = await customerService.GetCustomerAsync(id);
            if (supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind] SupplierCustomerEmployeeViewModel existingCustomer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await customerService.UpdateCustomerAsync(existingCustomer);
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
