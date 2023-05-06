
using Inventory.Entities.Entities;
using Inventory.Web.ViewModels;

namespace Inventory.Web.Services.ServiceInterface
{
    public interface ICustomer
    {
        Task CreateCustomerAsync(SupplierCustomerEmployeeViewModel customer);

        Task<IEnumerable<SupplierCustomerEmployeeViewModel?>> GetAllCustomersAsync();

        Task<SupplierCustomerEmployeeViewModel?> GetCustomerAsync(int Id);

        Task UpdateCustomerAsync(SupplierCustomerEmployeeViewModel existingCustomer);

        Task DeleteCustomerAsync(int Id);
    }
}
