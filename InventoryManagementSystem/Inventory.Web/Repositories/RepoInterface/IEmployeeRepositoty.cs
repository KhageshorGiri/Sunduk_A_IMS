using Inventory.Web.ViewModels;
using Microsoft.Data.SqlClient;

namespace Inventory.Web.Repositories.RepoInterface
{
    public interface IEmployeeRepositoty
    {
        Task CreateEmployeeAsync(EmployeeViewModel employee);

        Task<SqlDataReader?> GetAllEmployeesAsync();

        Task<SqlDataReader?> GetEmployeeAsync(int Id);

        Task UpddateEmployeeAsync(EmployeeViewModel existingEmployee);

        Task DeleteEmployeeAsync(int Id);
    }
}
