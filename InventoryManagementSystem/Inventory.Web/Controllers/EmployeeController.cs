using Inventory.Web.Services.ServiceImplementation;
using Inventory.Web.Services.ServiceInterface;
using Inventory.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Web.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly IWebHostEnvironment wenhostEnv;
        private readonly IEmployee employeeService;

        public EmployeeController(IWebHostEnvironment wenhostEnv, IEmployee employee)
        {
            this.wenhostEnv = wenhostEnv;
            this.employeeService = employee;
        }   

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var allSuppliersDetails = await employeeService.GetAllEmployeesAsync();
            return View(allSuppliersDetails);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int Id)
        {
            var employee = await employeeService.GetEmployeeAsync(Id);
            if(employee == null)
            {
                return NotFound();
            }    
            return View(employee);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind] EmployeeViewModel employee)
        {
            try 
            { 
                if (ModelState.IsValid)
                {
                    employee.ActiveDate = DateTime.UtcNow;
                    await employeeService.CreateEmployeeAsync(employee);
                    return RedirectToAction("Index", "Employee");
                }
                return View();
            }
            catch
            {
                return View();

            }
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int Id)
        {
            var employee = await employeeService.GetEmployeeAsync(Id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit([Bind] EmployeeViewModel employee)
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int Id)
        {
            var employee = await employeeService.GetEmployeeAsync(Id);
            if (employee == null)
            {
                return NotFound();
            }
            await employeeService.DeleteEmployeeAsync(Id);
            return RedirectToAction("Index","Employee");
        }
    }
}
