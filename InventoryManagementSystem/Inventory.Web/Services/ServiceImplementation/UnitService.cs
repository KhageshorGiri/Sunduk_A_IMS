
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

        public async Task<Unit?> GetUnitAsync(int Id)
        {
            var existingUnit = await _unitRepository.GetUnitAsync(Id);
            return existingUnit;
        }
      
        public async Task UpdateUnitAsync(Unit existingUnit)
        {
            await _unitRepository.UpdateUnitAsync(existingUnit);
        }
        public async Task DeleteUnitAsync(int Id)
        {
            await _unitRepository.DeleteUnitAsync(Id);
        }

    }
}
