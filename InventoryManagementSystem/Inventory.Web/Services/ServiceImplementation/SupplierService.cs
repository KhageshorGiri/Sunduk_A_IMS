
using Inventory.Entities.Entities;
using Inventory.Web.Repositories.RepoInterface;
using Inventory.Web.Services.ServiceInterface;
using Inventory.Web.ViewModels;

namespace Inventory.Web.Services.ServiceImplementation
{
    public class SupplierService : ISupplier
    {
        private readonly ISupplierRepository supplierRepository;
        public SupplierService(ISupplierRepository supplierRepo)
        {
            this.supplierRepository = supplierRepo;
        }

        public async Task CreateSupplierAsync(SupplierCustomerEmployeeViewModel supplier)
        {
            await supplierRepository.CreateSupplierAsync(supplier);
        }
        public async Task<IEnumerable<SupplierCustomerEmployeeViewModel?>> GetAllSuppliersAsync()
        {
            var suppliersDataReader = await supplierRepository.GetAllSuppliersAsync();

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

        public async Task<SupplierCustomerEmployeeViewModel?> GetSupplierAsync(int Id)
        {
            var existingSupplier = await supplierRepository.GetSupplierAsync(Id);

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

        public async Task UpddateSupplierAsync(SupplierCustomerEmployeeViewModel existingSupplier)
        {
            await supplierRepository.UpddateSupplierAsync(existingSupplier);
        }
        public async Task DeleteSupplierAsync(int Id)
        {
            await supplierRepository.DeleteSupplierAsync(Id);
        }
    }
}
