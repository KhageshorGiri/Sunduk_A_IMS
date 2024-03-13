using Inventory.Entities.Entities;
using Inventory.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Web.XOptionsConfiguration
{
    public static class DBSeed
    {
        public static async Task Seed(this WebApplication app)
        {
            try
            {
                using (var serviceProvider = app.Services.CreateScope())
                {
                    IServiceProvider provider = serviceProvider.ServiceProvider;
                    InventorySystemDbContext context = provider.GetRequiredService<InventorySystemDbContext>();

                    context.Database.EnsureCreated();

                    UserManager<Users> userManager = provider.GetRequiredService<UserManager<Users>>();
                    RoleManager<Role> roleManager = provider.GetRequiredService<RoleManager<Role>>();


                    //Seed roles
                    if(!await context.Roles.AnyAsync())
                    {
                        Role role = new Role
                        {
                            Name = "Admin",
                            NormalizedName = "Admin"
                        };

                        await roleManager.CreateAsync(role);
                    }

                    //Seed admin user
                    if (!await context.Users.AnyAsync())
                    {
                        Users user = new Users
                        {
                            Name = "Admin",
                            UserName = "admin@123.com",
                            Email = "admin@123.com"
                        };

                        //create user
                        var userResult = await userManager.CreateAsync(user, "Admin@123");
                        //Log.Information("Admin User Creation", userResult);

                        //assign admin role to user
                        var roleResult = await userManager.AddToRoleAsync(user, "Admin");
                        //Log.Information("Role Assignment to Admin", roleResult);
                    }

                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
