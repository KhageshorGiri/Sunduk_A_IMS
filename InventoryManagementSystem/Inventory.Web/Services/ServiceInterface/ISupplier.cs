
using Inventory.Entities.Entities;
using Inventory.Web.ViewModels;

namespace Inventory.Web.Services.ServiceInterface
{
    public interface ISupplier
    {
        Task CreateSupplierAsync(SupplierViewModel supplier);

        Task<IEnumerable<SupplierViewModel?>> GetAllSuppliersAsync();

        Task<SupplierViewModel?> GetSupplierAsync(int Id);

        Task UpddateSupplierAsync(SupplierViewModel existingSupplier);

        Task DeleteSupplierAsync(int Id);
    }
}
