using Inventory.Web.Repositories.repoImplementation;
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

        public async Task<IEnumerable<EmployeeViewModel?>> GetAllEmployeesAsync()
        {
            try
            {
                var employeeDataReader = await employeeRepositoty.GetAllEmployeesAsync();

                List<EmployeeViewModel> allEmployeeList = new();
                if(employeeDataReader != null)
                {
                    while (employeeDataReader.Read())
                    {
                        EmployeeViewModel employee = new EmployeeViewModel();
                        employee.EmployeeID = Convert.ToInt32(employeeDataReader["EmployeeId"]);
                        employee.EmployeeName = employeeDataReader["EmployeeName"].ToString();
                        employee.EmployeeEmail = employeeDataReader["Email"].ToString();
                        employee.PhoneNumber = employeeDataReader["PhoneNumber"].ToString();
                        employee.PanNumber = employeeDataReader["PanNumber"].ToString();
                        employee.ImagePath = employeeDataReader["ImageFile"].ToString();
                        employee.DateFoJoining = Convert.ToDateTime(employeeDataReader["DateFoJoining"]);
                        employee.Post = employeeDataReader["Post"].ToString();
                        employee.CurrentSalary = Convert.ToDecimal(employeeDataReader["SalaryAmount"]);
                        employee.Country = employeeDataReader["Country"].ToString();
                        employee.City = employeeDataReader["City"].ToString();
                        employee.LocalAddress = employeeDataReader["LocalAddress"].ToString();
                        allEmployeeList.Add(employee);
                    }
                }
                return allEmployeeList;
               
            }
            catch (Exception exp)
            {
                string message = exp.Message;
                throw new NotImplementedException();
            }
        }

        public async Task<EmployeeViewModel?> GetEmployeeAsync(int Id)
        {
            try
            {
                var existingEmployee = await employeeRepositoty.GetEmployeeAsync(Id);

                EmployeeViewModel employee = new EmployeeViewModel();
                if (existingEmployee != null)
                {
                    while (existingEmployee.Read())
                    {
                        employee.EmployeeID = Convert.ToInt32(existingEmployee["EmployeeId"]);
                        employee.EmployeeName = existingEmployee["EmployeeName"].ToString();
                        employee.EmployeeEmail = existingEmployee["Email"].ToString();
                        employee.PhoneNumber = existingEmployee["PhoneNumber"].ToString();
                        employee.PanNumber = existingEmployee["PanNumber"].ToString();
                        employee.ImagePath = existingEmployee["ImageFile"].ToString();
                        employee.DateFoJoining = Convert.ToDateTime(existingEmployee["DateFoJoining"]);
                        employee.Post = existingEmployee["Post"].ToString();
                        employee.CurrentSalary = Convert.ToDecimal(existingEmployee["SalaryAmount"]);
                        employee.Country = existingEmployee["Country"].ToString();
                        employee.City = existingEmployee["City"].ToString();
                        employee.LocalAddress = existingEmployee["LocalAddress"].ToString();
                    }
                }
                return employee;
            }
            catch(Exception ex)
            {
                string message = ex.Message;
            }
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
