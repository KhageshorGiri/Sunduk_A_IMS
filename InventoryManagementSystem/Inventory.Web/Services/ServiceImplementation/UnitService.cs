
using Inventory.Entities.Entities;
using Inventory.Web.Services.ServiceInterface;

namespace Inventory.Web.Services.ServiceImplementation
{
    public class UnitService : IUnit
    {
        private readonly IUnit _unitService;
        public UnitService(IUnit unitService)
        {
            this._unitService = unitService;
        }

        public Task CreateUnitAsync(Unit unit)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category?>> GetAllUnitsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Category?> GetUnitAsync(int Id)
        {
            throw new NotImplementedException();
        }
      
        public Task UpdateUnitAsync(Unit existingUnit)
        {
            throw new NotImplementedException();
        }
        public Task DeleteUnitAsync(int Id)
        {
            throw new NotImplementedException();
        }

    }
}
