
using Inventory.Web.ViewModels;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Inventory.Web.Repositories.RepoInterface
{
    public interface ICustomerRepository
    {
        Task CreateCustomerAsync(SupplierCustomerEmployeeViewModel customer);

        Task<SqlDataReader?> GetAllCustomersAsync();

        Task<SqlDataReader?> GetCustomerAsync(int Id);

        Task UpdateCustomerAsync(SupplierCustomerEmployeeViewModel existingCustomer);

        Task DeleteCustomerAsync(int Id);
    }
}
