

using Inventory.Entities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Web.Data
{
    public class InventorySystemDbContext : IdentityDbContext<Users, Role, string>
    {
        public InventorySystemDbContext(DbContextOptions<InventorySystemDbContext> options) 
            : base(options)
        {

        }

        // adding models that will maped into database tables

        public DbSet<Address>? Addresses { get; set; }
        public DbSet<Supplier>? Suppliers { get; set; }
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public  DbSet<Unit>? Units { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<Invoice>? Invoices { get; set; }
        public DbSet<InvoiceProducts>? InvoiceProducts { get; set; }
        public DbSet<BuyBill>? BuyBills { get; set; }
        public DbSet<Employee>? Employees { get; set; }
        public DbSet<EmployeeSalary>? EmployeeSalaries { get; set; }
        public DbSet<EmployeeSalaryPayment>? EmployeeSalaryPayments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
            .HasOne(p => p.BuyBill)
            .WithMany(b => b.Products)
            .HasForeignKey(p => p.BillId);

            modelBuilder.Entity<InvoiceProducts>()
          .HasOne(p => p.Invoice)
          .WithMany(b => b.InvoiceProducts)
          .HasForeignKey(p => p.InvoiceBillId);
        }
    }
}
