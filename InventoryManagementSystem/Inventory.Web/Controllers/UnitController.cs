using Inventory.Entities.Entities;
using Inventory.Web.Repositories.RepoInterface;
using Inventory.Web.Services.ServiceInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Web.Controllers
{
    [Authorize(Roles ="Admin")]
    public class UnitController : Controller
    {
        private readonly IUnit unitService;
        private readonly IUnitRepository unitRepo;
        public UnitController(IUnit unit, IUnitRepository unitRepository)
        {
            this.unitService = unit;
            this.unitRepo = unitRepository;
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
        public async Task<ActionResult> Create([Bind] Unit newUnit)
        {
            
            try
            {
                await unitService.CreateUnitAsync(newUnit);
                TempData["Message"] = "Create Success";
                return RedirectToAction(nameof(Create));
            }
            catch
            {
                TempData["Message"] = "Create Error";
                return View();
            }
        }

        // GET: UnitController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var existingUnit =  await unitService.GetUnitAsync(id);
            if(existingUnit == null)
            {               
                return NotFound();
            }
           
            return View(existingUnit);
        }

        // POST: UnitController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, [Bind] Unit collection)
        {
            try
            {
                var existingUnit = new Unit()
                {
                    UnitId = id,
                    UnitName = collection.UnitName,
                    ShortForm = collection.ShortForm
                };

                await unitService.UpdateUnitAsync(existingUnit);

                TempData["Message"] = "Edit Success";               
                return RedirectToAction(nameof(Create));
            }
            catch
            {
                TempData["Message"] = "Edit Error";
                return View();
            }
        }

        // GET: UnitController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {              
                await unitService.DeleteUnitAsync(id);
                TempData["Message"] = "Delete Success";
                return RedirectToAction("Create");
            }
            catch
            {
                TempData["Message"] = "Delete Error";
                return View();
            }
        }

        // POST: UnitController/Delete/5
        /* [HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult Delete(int id, IFormCollection collection)
         {
             try
             {
                 var existing 
                 return RedirectToAction("Create");
             }
             catch
             {
                 return View();
             }
         }*/
    }
}
