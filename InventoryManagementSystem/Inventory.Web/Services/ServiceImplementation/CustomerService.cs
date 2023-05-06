
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

        public async Task CreateCustomerAsync(SupplierCustomerEmployeeViewModel supplier)
        {
            await customerRepository.CreateCustomerAsync(supplier);
        }
        public async Task<IEnumerable<SupplierCustomerEmployeeViewModel?>> GetAllCustomersAsync()
        {
            var suppliersDataReader = await customerRepository.GetAllCustomersAsync();

            List<SupplierCustomerEmployeeViewModel> allSuppliers = new();
            if(suppliersDataReader != null)
            {
                while (suppliersDataReader.Read())
                {
                    SupplierCustomerEmployeeViewModel supplier = new SupplierCustomerEmployeeViewModel();
                    supplier.SupplierID = Convert.ToInt32(suppliersDataReader["SupplierId"]);
                    supplier.SupplierName = suppliersDataReader["SupplierName"].ToString();
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

        public async Task<SupplierCustomerEmployeeViewModel?> GetCustomerAsync(int Id)
        {
            var existingSupplier = await customerRepository.GetCustomerAsync(Id);

            SupplierCustomerEmployeeViewModel supplier = new SupplierCustomerEmployeeViewModel();
            if(existingSupplier != null)
            {
                while (existingSupplier.Read())
                {
                    supplier.SupplierID = Convert.ToInt32(existingSupplier["SupplierId"]);
                    supplier.SupplierName = existingSupplier["SupplierName"].ToString();
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

        public async Task UpdateCustomerAsync(SupplierCustomerEmployeeViewModel existingSupplier)
        {
            await customerRepository.UpdateCustomerAsync(existingSupplier);
        }
        public async Task DeleteCustomerAsync(int Id)
        {
            await customerRepository.DeleteCustomerAsync(Id);
        }
    }
}
