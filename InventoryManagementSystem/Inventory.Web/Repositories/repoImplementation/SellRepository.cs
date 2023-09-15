using Inventory.Entities.Entities;
using Inventory.Web.Data;
using Inventory.Web.Repositories.RepoInterface;
using Inventory.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Web.Repositories.repoImplementation
{
    public class SellRepository : ISellRepository
    {
        private readonly InventorySystemDbContext _dbContext;
        public SellRepository(InventorySystemDbContext context)
        { 
            this._dbContext = context;
        }
        public async Task AddSellBillAsync(SellBillViewModel invoiceBillItems)
        {
            var invoice = new Invoice();
            invoice.BillNumber = invoiceBillItems.BillNumber;
            invoice.BillIssueDate = Convert.ToDateTime(invoiceBillItems.BillIssueDate);
            invoice.VoucherDate = Convert.ToDateTime(invoiceBillItems.VoucherDate);
            invoice.CustomerID = invoiceBillItems.CustomerID;
            invoice.Comment = invoiceBillItems.Comment;
            invoice.SellDate = DateTime.UtcNow.ToString();
            _dbContext.Invoices.Add(invoice);

            await _dbContext.SaveChangesAsync();

            int invoiceBillId = invoice.InvoiceBillId;

            // adding into product table
            if (invoiceBillItems.Products != null)
            {
                foreach (var item in invoiceBillItems.Products)
                {
                    var product = new InvoiceProducts();
                    product.StockProductId = item.ProductId;
                    product.Rate = item.Rate;
                    product.Quantity = item.Quantity;
                    product.InvoiceBillId = invoiceBillId;
                    _dbContext.InvoiceProducts.Add(product);
                }
            }

            await _dbContext.SaveChangesAsync();

        }

        public Task DeleteSellBillAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Invoice?>> GetAllSellBillsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Invoice?> GetSellBillAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateSellBill(SellBillViewModel buyBill)
        {
            throw new NotImplementedException();
        }

        public async Task<Product?> GetProductByProductCode(string productCode)
        {
            var product = await _dbContext.Products
                .Include(x => x.Category)
                .Include(x => x.Unit)
                .FirstOrDefaultAsync(x => x.ProductCode == productCode);
            return  product;
        }

    }
}
