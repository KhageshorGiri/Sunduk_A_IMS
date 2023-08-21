using Inventory.Entities.Entities;
using Inventory.Web.Data;
using Inventory.Web.Helper;
using Inventory.Web.Repositories.RepoInterface;
using Inventory.Web.Services.ServiceInterface;
using Inventory.Web.ViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Inventory.Web.Repositories.repoImplementation
{
    public class BuyBillRepository : IBuyBillRepository
    {
        string connectionString = GetDbConnectionString.ReadDbConnectionString().GetConnectionString("DataBaseConnection");

        private readonly InventorySystemDbContext dbContext;

        public BuyBillRepository(InventorySystemDbContext _context)
        {
            this.dbContext = _context;
        }

        public async Task AddBuyBillAsync(BuyBillViewModel buyBillItems)
        {
            var buyBill = new BuyBill();
            buyBill.BillNumber = buyBillItems.BillNumber;
            buyBill.BillIssueDate = Convert.ToDateTime(buyBillItems.BillIssueDate);
            buyBill.VoucherDate = Convert.ToDateTime(buyBillItems.VoucherDate);
            buyBill.PurchaseDate = buyBillItems.PurchaseDate;
            buyBill.SupplierID = buyBillItems.SupplierID;
            buyBill.Comment = buyBillItems.Comment;
            dbContext.BuyBills.Add(buyBill);

            await dbContext.SaveChangesAsync();

            int billId = buyBill.BillId;

            // adding into product table
            if(buyBillItems.Products != null)
            {
                foreach (var item in buyBillItems.Products)
                {
                    var product = new Product();
                    product.ProductName = item.ProductName;
                    product.ProductCode = item.ProductCode;
                    product.Rate = item.Rate;
                    product.Quantity = item.Quantity;
                    product.ProductDescription = item.ProductDescription == null ? "Adding Product in Stock" : item.ProductDescription;
                    product.UnitId = Convert.ToInt32(item.UnitId);
                    product.CategoryId = Convert.ToInt32(item.CategoryId);
                    product.BillId = billId;
                    dbContext.Products.Add(product);
                }
            }

            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<BuyBill?>> GetAllBuyBillsAsync()
        {
            var billList = dbContext.BuyBills
                .Include(x => x.Products)
                .Include(x => x.Supplier);
               // .Include(x=>x.);
            return await billList.ToArrayAsync();
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





/*SqlConnection con = new SqlConnection(connectionString);

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
               SqlParameter parameter = cmd.Parameters.AddWithValue("@productData", productDataTable);
               parameter.SqlDbType = SqlDbType.Structured;
               parameter.TypeName = "ItemTableType"; // Name of the user-defined table type in SQL Server
               con.Open();
               await cmd.ExecuteNonQueryAsync();
           }*/