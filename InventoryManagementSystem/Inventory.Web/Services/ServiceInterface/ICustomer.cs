
using Inventory.Entities.Entities;
using Inventory.Web.ViewModels;

namespace Inventory.Web.Services.ServiceInterface
{
    public interface ICustomer
    {
        Task CreateCustomerAsync(CustomerViewModel customer);

        Task<IEnumerable<CustomerViewModel?>> GetAllCustomersAsync();

        Task<CustomerViewModel?> GetCustomerAsync(int Id);

        Task UpdateCustomerAsync(CustomerViewModel existingCustomer);

        Task DeleteCustomerAsync(int Id);
    }
}
