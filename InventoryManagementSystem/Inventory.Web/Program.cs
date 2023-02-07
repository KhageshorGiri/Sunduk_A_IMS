using Inventory.Web.Data;
using Inventory.Web.Repositories.repoImplementation;
using Inventory.Web.Repositories.RepoInterface;
using Inventory.Web.Services.ServiceImplementation;
using Inventory.Web.Services.ServiceInterface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// adding database throug connection string
builder.Services.AddDbContext<InventorySystemDbContext>(option =>
        option.UseSqlServer(builder.Configuration.GetConnectionString("DataBaseConnection")));

// adding services as a DI
builder.Services.AddTransient<IUnit, UnitService>();
builder.Services.AddTransient<IUnitRepository, UnitRepository>();
builder.Services.AddTransient<ICategory, CategoryService>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<ISupplier, SupplierService>();
builder.Services.AddTransient<ISupplierRepository, SupplierRepository>();
builder.Services.AddTransient<IBuyProduct, BuyProductService>();
builder.Services.AddTransient<IBuyBillRepository, BuyBillRepository>();
builder.Services.AddTransient<IEmployee, EmployeeService>();
builder.Services.AddTransient<IEmployeeRepositoty, EmployeeRepository>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
