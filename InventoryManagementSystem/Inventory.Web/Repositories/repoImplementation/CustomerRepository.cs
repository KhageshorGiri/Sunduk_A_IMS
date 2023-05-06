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
    public class CustomerRepository : ICustomerRepository
    {
        string connectionString = GetDbConnectionString.ReadDbConnectionString().GetConnectionString("DataBaseConnection");
        public async Task CreateCustomerAsync(SupplierCustomerEmployeeViewModel supplier)
        {
            SqlConnection con = new SqlConnection(connectionString);
            using (SqlCommand cmd = new SqlCommand("App_Customer_AddCustomer", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerName", supplier.SupplierName);
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
        
        public async Task<SqlDataReader?> GetAllCustomersAsync()
        {
            SqlDataReader allSuppliersList;
            SqlConnection con = new SqlConnection(connectionString);
            using (SqlCommand cmd = new SqlCommand("App_Customer_GetAllCustomers", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                allSuppliersList = await cmd.ExecuteReaderAsync();
                
            }
            return allSuppliersList;
        }

        public async Task<SqlDataReader?> GetCustomerAsync(int Id)
        {
            SqlDataReader supplier;
            SqlConnection con = new SqlConnection(connectionString);
            using (SqlCommand cmd = new SqlCommand("App_Customer_GetCustomer", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerId", Id);
                con.Open();
                supplier = await cmd.ExecuteReaderAsync();
            }
            return supplier;
        }

        public async Task UpdateCustomerAsync(SupplierCustomerEmployeeViewModel existingSupplier)
        {
            SqlConnection con = new SqlConnection(connectionString);
            using (SqlCommand cmd = new SqlCommand("App_Customer_UpdateCustomer", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerId", existingSupplier.SupplierID);
                cmd.Parameters.AddWithValue("@CustomerName", existingSupplier.SupplierName);
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
        public async Task DeleteCustomerAsync(int Id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            using (SqlCommand cmd = new SqlCommand("App_Customer_DeleteCustomer", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerId", Id);
                con.Open();
                await cmd.ExecuteNonQueryAsync();
            }
        }

    }
}
