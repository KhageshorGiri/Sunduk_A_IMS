
using Inventory.Web.ViewModels;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Inventory.Web.Repositories.RepoInterface
{
    public interface ICustomerRepository
    {
        Task CreateCustomerAsync(CustomerViewModel customer);

        Task<SqlDataReader?> GetAllCustomersAsync();

        Task<SqlDataReader?> GetCustomerAsync(int Id);

        Task UpdateCustomerAsync(CustomerViewModel existingCustomer);

        Task DeleteCustomerAsync(int Id);
    }
}
