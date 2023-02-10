using Inventory.Web.ViewModels;

namespace Inventory.Web.Repositories.RepoInterface
{
    public interface IEmployeeRepositoty
    {
        Task CreateEmployeeAsync(EmployeeViewModel employee);

        Task<IEnumerable<EmployeeViewModel?>> GetAllEmployeesAsync();

        Task<EmployeeViewModel?> GetEmployeeAsync(int Id);

        Task UpddateEmployeeAsync(EmployeeViewModel existingEmployee);

        Task DeleteEmployeeAsync(int Id);
    }
}
