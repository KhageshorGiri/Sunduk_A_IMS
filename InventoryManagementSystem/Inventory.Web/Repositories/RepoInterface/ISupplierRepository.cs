
using Inventory.Web.ViewModels;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Inventory.Web.Repositories.RepoInterface
{
    public interface ISupplierRepository
    {
        Task CreateSupplierAsync(SupplierViewModel supplier);

        Task<SqlDataReader?> GetAllSuppliersAsync();

        Task<SqlDataReader?> GetSupplierAsync(int Id);

        Task UpddateSupplierAsync(SupplierViewModel existingSupplier);

        Task DeleteSupplierAsync(int Id);
    }
}
