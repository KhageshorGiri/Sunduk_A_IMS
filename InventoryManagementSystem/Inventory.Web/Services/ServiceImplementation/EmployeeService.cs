using Inventory.Web.Services.ServiceInterface;
using Inventory.Web.ViewModels;

namespace Inventory.Web.Services.ServiceImplementation
{
    public class EmployeeService : IEmployee
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
