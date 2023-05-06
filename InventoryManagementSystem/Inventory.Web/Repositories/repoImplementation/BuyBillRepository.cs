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

            DataTable productDataTable = new DataTable();
            //Add columns  
            productDataTable.Columns.Add(new DataColumn("ProductName", typeof(string)));
            productDataTable.Columns.Add(new DataColumn("Rate", typeof(string)));
            productDataTable.Columns.Add(new DataColumn("Quantity", typeof(string)));
            productDataTable.Columns.Add(new DataColumn("UnitId", typeof(int)));
            productDataTable.Columns.Add(new DataColumn("CategoryId", typeof(int)));
            //Add rows  
            if(buyBillItems.Products != null)
            {
                foreach (var product in buyBillItems.Products)
                {
                    productDataTable.Rows.Add(product.ProductName,product.Rate,product.Quantity,product.UnitId,product.CategoryId);
                }
            }
           
            using (SqlCommand cmd = new SqlCommand("", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@", "Value");
                cmd.Parameters.AddWithValue("@", "Value");
                cmd.Parameters.AddWithValue("@", "Value");
                cmd.Parameters.AddWithValue("@productData", productDataTable);
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
