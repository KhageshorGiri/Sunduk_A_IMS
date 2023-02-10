using Inventory.Web.Repositories.RepoInterface;
using Inventory.Web.Services.ServiceInterface;
using Inventory.Web.ViewModels;

namespace Inventory.Web.Services.ServiceImplementation
{
    public class EmployeeService : IEmployee
    {
        private readonly IWebHostEnvironment wenhostEnv;
        private readonly IEmployeeRepositoty employeeRepositoty;

        public EmployeeService(IWebHostEnvironment wenhostEnv, IEmployeeRepositoty employeeRepositoty)
        {
            this.wenhostEnv = wenhostEnv;
            this.employeeRepositoty = employeeRepositoty;   
        }

        public async Task CreateEmployeeAsync(EmployeeViewModel employee)
        {
            try
            {
                if (employee.Image != null)
                {
                    string rootFolder = Path.Combine(wenhostEnv.WebRootPath, "App_Data/Images");
                    string fileName = employee.Image.FileName;
                    string uniqueName = Guid.NewGuid().ToString() + "_" + fileName;
                    string ImageFilePath = Path.Combine(rootFolder, uniqueName);
                    employee.Image.CopyTo(new FileStream(ImageFilePath, FileMode.Create));
                    employee.ImagePath = Path.Combine("App_Data/Images", uniqueName);
                }

                await employeeRepositoty.CreateEmployeeAsync(employee);
            }
            catch(Exception exp)
            {
                string message = exp.Message;
            }
           
        }

        public Task<IEnumerable<EmployeeViewModel?>> GetAllEmployeesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeViewModel?> GetEmployeeAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task UpddateEmployeeAsync(EmployeeViewModel existingEmployee)
        {
            throw new NotImplementedException();
        }
        public Task DeleteEmployeeAsync(int Id)
        {
            throw new NotImplementedException();
        }

    }
}
