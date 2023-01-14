
using Inventory.Entities.Entities;
using Inventory.Web.ViewModels;

namespace Inventory.Web.Services.ServiceInterface
{
    public interface ISupplier
    {
        Task CreateSupplierAsync(SupplierCustomerEmployeeViewModel supplier);

        Task<IEnumerable<SupplierCustomerEmployeeViewModel?>> GetAllSuppliersAsync();

        Task<SupplierCustomerEmployeeViewModel?> GetSupplierAsync(int Id);

        Task UpddateSupplierAsync(SupplierCustomerEmployeeViewModel existingSupplier);

        Task DeleteSupplierAsync(int Id);
    }
}
