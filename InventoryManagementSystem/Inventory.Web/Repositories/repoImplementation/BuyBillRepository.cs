using Inventory.Entities.Entities;
using Inventory.Web.Helper;
using Inventory.Web.Repositories.RepoInterface;
using Inventory.Web.Services.ServiceInterface;
using Inventory.Web.ViewModels;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Inventory.Web.Repositories.repoImplementation
{
    public class BuyBillRepository : IBuyBillRepository
    {
        string connectionString = GetDbConnectionString.ReadDbConnectionString().GetConnectionString("DataBaseConnection");
        public async Task AddBuyBillAsync(BuyBillViewModel buyBillItems)
        {
            SqlConnection con = new SqlConnection(connectionString);
            using (SqlCommand cmd = new SqlCommand("", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@", "Value");
                con.Open();
                await cmd.ExecuteNonQueryAsync();
            }

            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BuyBill?>> GetAllBuyBillsAsync()
        {
            SqlConnection con = new SqlConnection(connectionString);
            using (SqlCommand cmd = new SqlCommand("", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@", "Value");
                con.Open();
                await cmd.ExecuteNonQueryAsync();
            }

            throw new NotImplementedException();
        }

        public async Task<BuyBill?> GetBuyBillAsync()
        {
            SqlConnection con = new SqlConnection(connectionString);
            using (SqlCommand cmd = new SqlCommand("", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@", "Value");
                con.Open();
                await cmd.ExecuteNonQueryAsync();
            }

            throw new NotImplementedException();
        }

        public async Task UpdateBuyBill(BuyBillViewModel buyBill)
        {
            SqlConnection con = new SqlConnection(connectionString);
            using (SqlCommand cmd = new SqlCommand("", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@", "Value");
                con.Open();
                await cmd.ExecuteNonQueryAsync();
            }

            throw new NotImplementedException();
        }
        public async Task DeleteBuyBillAsync(int Id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            using (SqlCommand cmd = new SqlCommand("", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@", "Value");
                con.Open();
                await cmd.ExecuteNonQueryAsync();
            }

            throw new NotImplementedException();
        }

    }
}
