

using Inventory.Web.Services.ServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Web.ViewComponets
{
    public class UnitIndexViewComponent : ViewComponent
    {
        private readonly IUnit unitService;
        public UnitIndexViewComponent(IUnit unitService)
        {
            this.unitService = unitService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var unitList = await unitService.GetAllUnitsAsync();
            return View(unitList);
        }
    }
}
