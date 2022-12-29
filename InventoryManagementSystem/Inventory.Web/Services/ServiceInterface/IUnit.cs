using Inventory.Entities.Entities;

namespace Inventory.Web.Services.ServiceInterface
{
    public interface IUnit
    {
        Task CreateUnitAsync(Unit unit);

        Task<IEnumerable<Unit?>> GetAllUnitsAsync();

        Task<Unit?> GetUnitAsync(int Id);

        Task UpdateUnitAsync(Unit existingUnit);

        Task DeleteUnitAsync(int Id);
    }
}
