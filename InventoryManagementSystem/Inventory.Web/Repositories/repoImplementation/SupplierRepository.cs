using Inventory.Entities.Entities;
using Inventory.Web.Helper;
using Inventory.Web.Repositories.RepoInterface;
using Inventory.Web.ViewModels;
using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Diagnostics.Metrics;

namespace Inventory.Web.Repositories.repoImplementation
{
    public class SupplierRepository : ISupplierRepository
    {
        string connectionString = GetDbConnectionString.ReadDbConnectionString().GetConnectionString("DataBaseConnection");
        public async Task CreateSupplierAsync(SupplierCustomerEmployeeViewModel supplier)
        {
            SqlConnection con = new SqlConnection(connectionString);
            using (SqlCommand cmd = new SqlCommand("App_Supplier_AddSupplier", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SupplierName", supplier.SupplierName);
                cmd.Parameters.AddWithValue("@Email", supplier.Email);
                cmd.Parameters.AddWithValue("@PhoneNumber", supplier.PhoneNumber);
                cmd.Parameters.AddWithValue("@PanNumber", supplier.PanNumber);
                cmd.Parameters.AddWithValue("@Country", supplier.Country);
                cmd.Parameters.AddWithValue("@City", supplier.City);
                cmd.Parameters.AddWithValue("@LocalAddress", supplier.LocalAddress);
                con.Open();
                await cmd.ExecuteNonQueryAsync();
            }
        }
        
        public async Task<SqlDataReader?> GetAllSuppliersAsync()
        {
            SqlDataReader allSuppliersList;
            SqlConnection con = new SqlConnection(connectionString);
            using (SqlCommand cmd = new SqlCommand("App_Supplier_GetAllSuppliers", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                allSuppliersList = await cmd.ExecuteReaderAsync();
                
            }
            return allSuppliersList;
        }

        public async Task<SqlDataReader?> GetSupplierAsync(int Id)
        {
            SqlDataReader supplier;
            SqlConnection con = new SqlConnection(connectionString);
            using (SqlCommand cmd = new SqlCommand("App_Supplier_GetSupplier", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SupplierId", Id);
                con.Open();
                supplier = await cmd.ExecuteReaderAsync();
            }
            return supplier;
        }

        public async Task UpddateSupplierAsync(SupplierCustomerEmployeeViewModel existingSupplier)
        {
            SqlConnection con = new SqlConnection(connectionString);
            using (SqlCommand cmd = new SqlCommand("App_Supplier_UpdateSupplier", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SupplierId", existingSupplier.SupplierID);
                cmd.Parameters.AddWithValue("@SupplierName", existingSupplier.SupplierName);
                cmd.Parameters.AddWithValue("@Email", existingSupplier.Email);
                cmd.Parameters.AddWithValue("@PhoneNumber", existingSupplier.PhoneNumber);
                cmd.Parameters.AddWithValue("@PanNumber", existingSupplier.PanNumber);
                cmd.Parameters.AddWithValue("@AddressId", existingSupplier.AddressId);
                cmd.Parameters.AddWithValue("@Country", existingSupplier.Country);
                cmd.Parameters.AddWithValue("@City", existingSupplier.City);
                cmd.Parameters.AddWithValue("@LocalAddress", existingSupplier.LocalAddress);
                con.Open();
                await cmd.ExecuteNonQueryAsync();
            }
        }
        public async Task DeleteSupplierAsync(int Id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            using (SqlCommand cmd = new SqlCommand("App_Supplier_DeleteSupplier", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SupplierId", Id);
                con.Open();
                await cmd.ExecuteNonQueryAsync();
            }
        }

    }
}
/*SqlConnection con = new SqlConnection(configuration);
          using(SqlCommand cmd = new SqlCommand("sp", con))
          {
              cmd.CommandType = CommandType.StoredProcedure;
              cmd.Parameters.AddWithValue("@Parameter1", "value1");
              con.Open();
              await cmd.ExecuteNonQueryAsync();
          }            */