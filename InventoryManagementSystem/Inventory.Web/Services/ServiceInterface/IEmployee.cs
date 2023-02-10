using Inventory.Web.ViewModels;

namespace Inventory.Web.Services.ServiceInterface
{
    public interface IEmployee
    {
        Task CreateEmployeeAsync(EmployeeViewModel employee);

        Task<IEnumerable<EmployeeViewModel?>> GetAllEmployeesAsync();

        Task<EmployeeViewModel?> GetEmployeeAsync(int Id);

        Task UpddateEmployeeAsync(EmployeeViewModel existingEmployee);

        Task DeleteEmployeeAsync(int Id);
    }
}
