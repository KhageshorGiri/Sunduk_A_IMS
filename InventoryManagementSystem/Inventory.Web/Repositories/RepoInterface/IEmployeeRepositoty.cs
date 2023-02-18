using Inventory.Web.ViewModels;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Inventory.Web.Repositories.RepoInterface
{
    public interface IEmployeeRepositoty
    {
        Task CreateEmployeeAsync(EmployeeViewModel employee);

        Task<SqlDataReader?> GetAllEmployeesAsync();

        Task<DataSet?> GetEmployeeAsync(int Id);

        Task UpddateEmployeeAsync(EmployeeViewModel existingEmployee);

        Task DeleteEmployeeAsync(int Id);
    }
}
