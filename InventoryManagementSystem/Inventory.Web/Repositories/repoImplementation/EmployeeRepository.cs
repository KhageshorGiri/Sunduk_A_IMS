using Inventory.Entities.Entities;
using Inventory.Web.Helper;
using Inventory.Web.Repositories.RepoInterface;
using Inventory.Web.ViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Hosting;
using System.Data;
using System.Diagnostics.Metrics;

namespace Inventory.Web.Repositories.repoImplementation
{
    public class EmployeeRepository : IEmployeeRepositoty
    {

        string connectionString = GetDbConnectionString.ReadDbConnectionString().GetConnectionString("DataBaseConnection");

        public async Task CreateEmployeeAsync(EmployeeViewModel employee)
        {
            SqlConnection con = new SqlConnection(connectionString);
            using (SqlCommand cmd = new SqlCommand("App_Employee_AddEmployee", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
                cmd.Parameters.AddWithValue("@Email", employee.EmployeeEmail);
                cmd.Parameters.AddWithValue("PhoneNumber", employee.PhoneNumber);
                cmd.Parameters.AddWithValue("@PanNumber", employee.PanNumber);
                cmd.Parameters.AddWithValue("@ImageFile", employee.ImagePath);
                cmd.Parameters.AddWithValue("@Post", employee.Post);
                cmd.Parameters.AddWithValue("@JoiningDate", employee.DateFoJoining);
                cmd.Parameters.AddWithValue("@CurrentSalary", employee.CurrentSalary);
                cmd.Parameters.AddWithValue("@Country", employee.Country);
                cmd.Parameters.AddWithValue("@City", employee.City);
                cmd.Parameters.AddWithValue("@LocalAddress", employee.LocalAddress);
                cmd.Parameters.AddWithValue("@ActiveStatus", true);
                con.Open();
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task<SqlDataReader?> GetAllEmployeesAsync()
        {
            SqlDataReader allEmployeeList;
            SqlConnection con = new SqlConnection(connectionString);
            using (SqlCommand cmd = new SqlCommand("App_Employee_GetAllEmployee", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                allEmployeeList = await cmd.ExecuteReaderAsync();

            }
            return allEmployeeList;
        }

        public async Task<SqlDataReader?> GetEmployeeAsync(int Id)
        {
            SqlDataReader existingEmployee;
            SqlConnection con = new SqlConnection(connectionString);
            using (SqlCommand cmd = new SqlCommand("App_Employee_GetEmployee", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeID", Id);
                con.Open();
                existingEmployee = await cmd.ExecuteReaderAsync();

            }
            return existingEmployee;
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
