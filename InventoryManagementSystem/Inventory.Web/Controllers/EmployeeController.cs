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
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Details(int Id)
        {
            return View();
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
        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit([Bind] EmployeeViewModel employee)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            return View();
        }
    }
}
