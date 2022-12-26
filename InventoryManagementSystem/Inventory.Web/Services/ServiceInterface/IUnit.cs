﻿using Inventory.Entities.Entities;

namespace Inventory.Web.Services.ServiceInterface
{
    public interface IUnit
    {
        Task CreateUnitAsync(Unit unit);

        Task<IEnumerable<Category?>> GetAllUnitsAsync();

        Task<Category?> GetUnitAsync(int Id);

        Task UpdateUnitAsync(Unit existingUnit);

        Task DeleteUnitAsync(int Id);
    }
}
