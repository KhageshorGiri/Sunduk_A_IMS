
using Inventory.Entities.Entities;
using Inventory.Web.Data;
using Inventory.Web.Repositories.RepoInterface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Inventory.Web.Repositories.repoImplementation
{
    public class UnitRepository : IUnitRepository
    {
        string configuration = new ConfigurationManager().GetConnectionString("DataBaseConnection");

        private readonly InventorySystemDbContext dbContext;
        public UnitRepository(InventorySystemDbContext context)
        {
            this.dbContext = context;
        }
        public async Task CreateUnitAsync(Unit unit)
        {
            try
            {  
                await dbContext.Units.AddAsync(unit);
                dbContext.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<IEnumerable<Unit?>> GetAllUnitsAsync()
        {
            var unitList = dbContext.Units;
            return await unitList.ToListAsync();
        }

        public async Task<Unit?> GetUnitAsync(int Id)
        {
           var unit = await dbContext.Units.FindAsync(Id);
            return unit;
        }

        public async Task UpdateUnitAsync(Unit existingUnit)
        {
            dbContext.Entry(existingUnit).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
        public async Task DeleteUnitAsync(int Id)
        {
            var unit = GetUnitAsync(Id);
            dbContext.Remove(unit);
            await dbContext.SaveChangesAsync();
        }
    }

    /*SqlConnection con = new SqlConnection(configuration);
          using(SqlCommand cmd = new SqlCommand("sp", con))
          {
              cmd.CommandType = CommandType.StoredProcedure;
              cmd.Parameters.AddWithValue("@Parameter1", "value1");
              con.Open();
              await cmd.ExecuteNonQueryAsync();
          }            */

}
