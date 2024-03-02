using Inventory.Entities.Entities;
using Inventory.Web.Services.ServiceInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Web.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ICategory _categoryService;

        public CategoryController(ICategory categoryService)
        {
            _categoryService = categoryService;
        }


        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind] Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _categoryService.CreateCategoryAsync(category);
                    TempData["Message"] = "Create Success";                    
                }
                return RedirectToAction("Create");
            }
            catch
            {
                TempData["Message"] = "Create Error";
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var existingCategory = await _categoryService.GetCategoryAsync(id);
            if(existingCategory == null)
            {
                return NotFound();
            }
            return View(existingCategory);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, [Bind] Category existingCateory)
        {
            try
            {
                await _categoryService.UpdateCategoryAsync(id, existingCateory);
                TempData["Message"] = "Edit Success";
                return RedirectToAction(nameof(Create));
            }
            catch
            {
                TempData["Message"] = "Edit Error";
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                _categoryService.DeleteCategoryAsync(id);
                TempData["Message"] = "Delete Success";
                return RedirectToAction(nameof(Create));
            }
            catch
            {
                TempData["Message"] = "Delete Error";
                return View();
            }
        }
       
    }
}
