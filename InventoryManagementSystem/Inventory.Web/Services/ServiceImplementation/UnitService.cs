
using Inventory.Entities.Entities;
using Inventory.Web.Repositories.RepoInterface;
using Inventory.Web.Services.ServiceInterface;

namespace Inventory.Web.Services.ServiceImplementation
{
    public class UnitService : IUnit
    {
        private readonly IUnitRepository _unitRepository;
        public UnitService(IUnitRepository unitRepository)
        {
            this._unitRepository = unitRepository;
        }

        public async Task CreateUnitAsync(Unit unit)
        {
            await _unitRepository.CreateUnitAsync(unit);
        }

        public async Task<IEnumerable<Unit?>> GetAllUnitsAsync()
        {
            var allUnitsDetails = await _unitRepository.GetAllUnitsAsync();
            return allUnitsDetails;
        }

        public Task<Unit?> GetUnitAsync(int Id)
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
