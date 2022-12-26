
using Inventory.Entities.Entities;
using Inventory.Web.Repositories.RepoInterface;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Inventory.Web.Repositories.repoImplementation
{
    public class UnitRepository : IUnitRepository
    {
        string configuration = new ConfigurationManager().GetConnectionString("DataBaseConnection");
        
        public async Task CreateUnitAsync(Unit unit)
        {
            SqlConnection con = new SqlConnection(configuration);
            using(SqlCommand cmd = new SqlCommand("sp", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Parameter1", "value1");
                con.Open();
                await cmd.ExecuteNonQueryAsync();
            }            
        }

        public Task<IEnumerable<Category?>> GetAllUnitsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Category?> GetUnitAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUnitAsync(Unit existingUnit)
        {
            throw new NotImplementedException();
        }
        public Task DeleteUnitAsync(int Id)
        {
            throw new NotImplementedException();
        }
    }

   
}
