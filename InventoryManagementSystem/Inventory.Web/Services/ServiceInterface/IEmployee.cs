using Inventory.Web.ViewModels;

namespace Inventory.Web.Services.ServiceInterface
{
    public interface IEmployee
    {
        Task CreateEmployeeAsync(SupplierCustomerEmployeeViewModel employee);

        Task<IEnumerable<SupplierCustomerEmployeeViewModel?>> GetAllEmployeesAsync();

        Task<SupplierCustomerEmployeeViewModel?> GetEmployeeAsync(int Id);

        Task UpddateEmployeeAsync(SupplierCustomerEmployeeViewModel existingEmployee);

        Task DeleteEmployeeAsync(int Id);
    }
}
