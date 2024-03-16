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


            // Begin transaction
            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
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

                        // update prduct table for sold quantity
                        var strockProduct = await _dbContext.Products.FindAsync(item.ProductId);
                        if (strockProduct != null)
                        {
                            strockProduct.SoldQuantity = strockProduct.SoldQuantity + (int)item.Quantity;
                            _dbContext.Products.Update(strockProduct);
                        }
                    }
                }

                await _dbContext.SaveChangesAsync();

                // Commit transaction if all operations succeed
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                // Handle any exceptions and roll back the transaction
                await transaction.RollbackAsync();
                // Log or handle the exception as needed
            }
        }

        public Task DeleteSellBillAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Invoice?>> GetAllSellBillsAsync()
        {
            var allInvocies = await _dbContext.Invoices
                .Include(i=>i.Customer)
                .Include(invoice => invoice.InvoiceProducts)
                .OrderByDescending(i=>i.InvoiceBillId)
                .ToArrayAsync();

            return allInvocies;
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
