
using Inventory.Entities.Entities;
using Inventory.Web.Repositories.RepoInterface;
using Inventory.Web.Services.ServiceInterface;
using Inventory.Web.ViewModels;

namespace Inventory.Web.Services.ServiceImplementation
{
    public class CustomerService : ICustomer
    {
        private readonly ICustomerRepository customerRepository;
        public CustomerService(ICustomerRepository customerRepo)
        {
            this.customerRepository = customerRepo;
        }

        public async Task CreateCustomerAsync(CustomerViewModel supplier)
        {
            await customerRepository.CreateCustomerAsync(supplier);
        }
        public async Task<IEnumerable<CustomerViewModel?>> GetAllCustomersAsync()
        {
            var suppliersDataReader = await customerRepository.GetAllCustomersAsync();

            List<CustomerViewModel> allSuppliers = new();
            if(suppliersDataReader != null)
            {
                while (suppliersDataReader.Read())
                {
                    CustomerViewModel supplier = new CustomerViewModel();
                    supplier.CustomerID = Convert.ToInt32(suppliersDataReader["CustomerId"]);
                    supplier.CustomerName = suppliersDataReader["CustomerName"].ToString();
                    supplier.Email = suppliersDataReader["Email"].ToString();
                    supplier.PhoneNumber = suppliersDataReader["PhoneNumber"].ToString();
                    supplier.PanNumber = suppliersDataReader["PanNumber"].ToString();
                    supplier.AddressId = Convert.ToInt32(suppliersDataReader["AddressId"]);
                    supplier.City = suppliersDataReader["City"].ToString();
                    supplier.Country = suppliersDataReader["Country"].ToString();
                    supplier.LocalAddress = suppliersDataReader["LocalAddress"].ToString();
                    allSuppliers.Add(supplier);
                }
            }
            return allSuppliers;
        }

        public async Task<CustomerViewModel?> GetCustomerAsync(int Id)
        {
            var existingSupplier = await customerRepository.GetCustomerAsync(Id);

            CustomerViewModel supplier = new CustomerViewModel();
            if(existingSupplier != null)
            {
                while (existingSupplier.Read())
                {
                    supplier.CustomerID = Convert.ToInt32(existingSupplier["CustomerId"]);
                    supplier.CustomerName = existingSupplier["CustomerName"].ToString();
                    supplier.Email = existingSupplier["Email"].ToString();
                    supplier.PhoneNumber = existingSupplier["PhoneNumber"].ToString();
                    supplier.PanNumber = existingSupplier["PanNumber"].ToString();
                    supplier.AddressId = Convert.ToInt32(existingSupplier["AddressId"]);
                    supplier.City = existingSupplier["City"].ToString();
                    supplier.Country = existingSupplier["Country"].ToString();
                    supplier.LocalAddress = existingSupplier["LocalAddress"].ToString();
                }
            }
            return supplier;
        }

        public async Task UpdateCustomerAsync(CustomerViewModel existingSupplier)
        {
            await customerRepository.UpdateCustomerAsync(existingSupplier);
        }
        public async Task DeleteCustomerAsync(int Id)
        {
            await customerRepository.DeleteCustomerAsync(Id);
        }
    }
}
