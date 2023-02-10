using Inventory.Entities.Entities;
using Inventory.Web.Helper;
using Inventory.Web.Repositories.RepoInterface;
using Inventory.Web.ViewModels;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Inventory.Web.Repositories.repoImplementation
{
    public class EmployeeRepository : IEmployeeRepositoty
    {

        string connectionString = GetDbConnectionString.ReadDbConnectionString().GetConnectionString("DataBaseConnection");

        public async Task CreateEmployeeAsync(EmployeeViewModel employee)
        {
            SqlConnection con = new SqlConnection(connectionString);
            using (SqlCommand cmd = new SqlCommand("procuder", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SupplierName", "Value");
               
                con.Open();
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public Task<IEnumerable<EmployeeViewModel?>> GetAllEmployeesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeViewModel?> GetEmployeeAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task UpddateEmployeeAsync(EmployeeViewModel existingEmployee)
        {
            throw new NotImplementedException();
        }
        public Task DeleteEmployeeAsync(int Id)
        {
            throw new NotImplementedException();
        }

    }
}
