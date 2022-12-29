using Inventory.Entities.Entities;
using Inventory.Web.Data;
using Inventory.Web.Services.ServiceInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.ProjectModel;

namespace Inventory.Web.Controllers
{
    public class UnitController : Controller
    {
        private readonly IUnit unitService;
        public UnitController(IUnit unit)
        {
            this.unitService = unit;
        }

        public async Task<ActionResult> PartialIndex()
        {
            var unitDetails = await unitService.GetAllUnitsAsync();
            return View(unitDetails);
        }

        // GET: UnitController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UnitController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UnitController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind] Unit newUnit)
        {
            
            try
            {
                unitService.CreateUnitAsync(newUnit);
                TempData["Message"] = "Sucess";
                return RedirectToAction(nameof(Create));
            }
            catch
            {
                TempData["Message"] = "Error";
                return View();
            }
        }

        // GET: UnitController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UnitController/Edit/5
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

        // GET: UnitController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UnitController/Delete/5
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
