
using Inventory.Web.ViewModels;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Inventory.Web.Repositories.RepoInterface
{
    public interface ISupplierRepository
    {
        Task CreateSupplierAsync(SupplierCustomerEmployeeViewModel supplier);

        Task<SqlDataReader?> GetAllSuppliersAsync();

        Task<SqlDataReader?> GetSupplierAsync(int Id);

        Task UpddateSupplierAsync(SupplierCustomerEmployeeViewModel existingSupplier);

        Task DeleteSupplierAsync(int Id);
    }
}
