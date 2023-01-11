

using Inventory.Web.Services.ServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Web.ViewComponets
{
    public class CategoryIndexViewComponent : ViewComponent
    {
        private readonly ICategory _categoryService;
        public CategoryIndexViewComponent(ICategory categoryService)
        {
            this._categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var CategoryList = await _categoryService.GetAllCategoriesAsync();
            return View(CategoryList);
        }
    }
}
