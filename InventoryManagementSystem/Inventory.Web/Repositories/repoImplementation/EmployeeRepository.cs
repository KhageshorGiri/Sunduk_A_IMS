using Inventory.Web.Repositories.RepoInterface;
using Inventory.Web.ViewModels;

namespace Inventory.Web.Repositories.repoImplementation
{
    public class EmployeeRepository : IEmployeeRepositoty
    {
        public Task CreateEmployeeAsync(SupplierCustomerEmployeeViewModel employee)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SupplierCustomerEmployeeViewModel?>> GetAllEmployeesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<SupplierCustomerEmployeeViewModel?> GetEmployeeAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task UpddateEmployeeAsync(SupplierCustomerEmployeeViewModel existingEmployee)
        {
            throw new NotImplementedException();
        }
        public Task DeleteEmployeeAsync(int Id)
        {
            throw new NotImplementedException();
        }

    }
}
