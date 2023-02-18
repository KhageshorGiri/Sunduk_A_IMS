using Inventory.Entities.Entities;
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

                if(existingEmployee != null)
                {
                    if (existingEmployee.Tables[0].Rows.Count > 0)
                    {
                        employee.EmployeeID = Convert.ToInt32(existingEmployee.Tables[0].Rows[0]["EmployeeId"]);
                        employee.EmployeeName = existingEmployee.Tables[0].Rows[0]["EmployeeName"].ToString();
                        employee.EmployeeEmail = existingEmployee.Tables[0].Rows[0]["Email"].ToString();
                        employee.PhoneNumber = existingEmployee.Tables[0].Rows[0]["PhoneNumber"].ToString();
                        employee.PanNumber = existingEmployee.Tables[0].Rows[0]["PanNumber"].ToString();
                        employee.ImagePath = existingEmployee.Tables[0].Rows[0]["ImageFile"].ToString();
                        employee.DateFoJoining = Convert.ToDateTime(existingEmployee.Tables[0].Rows[0]["DateFoJoining"]);
                        employee.Post = existingEmployee.Tables[0].Rows[0]["Post"].ToString();
                        employee.CurrentSalary = Convert.ToDecimal(existingEmployee.Tables[0].Rows[0]["SalaryAmount"]);
                        employee.Country = existingEmployee.Tables[0].Rows[0]["Country"].ToString();
                        employee.City = existingEmployee.Tables[0].Rows[0]["City"].ToString();
                        employee.LocalAddress = existingEmployee.Tables[0].Rows[0]["LocalAddress"].ToString();

                        var salayrDetalisTable = existingEmployee.Tables[1];
                        if(salayrDetalisTable.Rows.Count > 0)
                        {
                            List<EmployeeSalary> salaryList = new List<EmployeeSalary>();
                            for (int i = 0; i < salayrDetalisTable.Rows.Count; i++)
                            {
                                EmployeeSalary empSalary = new EmployeeSalary();
                                empSalary.SalaryId = Convert.ToInt32(salayrDetalisTable.Rows[i]["SalaryId"]);
                                empSalary.SalaryAmount = Convert.ToInt32(salayrDetalisTable.Rows[i]["SalaryAmount"]);
                                empSalary.ActiveDate = (salayrDetalisTable.Rows[i]["ActiveDate"].ToString() == null ? Convert.ToDateTime(salayrDetalisTable.Rows[i]["ActiveDate"]) : null);
                                salaryList.Add(empSalary);
                            }
                            employee.EmployeeSalary = salaryList;
                        }
                       
                        var salayrPaymentTable = existingEmployee.Tables[2];
                        if (salayrPaymentTable.Rows.Count > 0)
                        {
                            List<EmployeeSalaryPayment> paymentList = new List<EmployeeSalaryPayment>();
                            for (int i = 0; i < salayrDetalisTable.Rows.Count; i++)
                            {
                                EmployeeSalaryPayment empPayment = new EmployeeSalaryPayment();
                                empPayment.PaymentID = Convert.ToInt32(salayrPaymentTable.Rows[i]["PaymentID"]);
                                empPayment.PayedAmount = Convert.ToDecimal(salayrPaymentTable.Rows[i]["PayedAmount"]);
                                empPayment.PaymentDate = Convert.ToDateTime(salayrPaymentTable.Rows[i]["PaymentDate"]);
                                empPayment.Remarks = salayrPaymentTable.Rows[i]["Remarks"].ToString();
                                paymentList.Add(empPayment);
                            }
                            employee.SalaryPayment = paymentList;
                        }
                        
                    }
                }
                
                return employee;
            }
            catch(Exception ex)
            {
                string message = ex.Message;
                return null;
            }
            
        }

        public Task UpddateEmployeeAsync(EmployeeViewModel existingEmployee)
        {
            throw new NotImplementedException();
        }
        public async Task DeleteEmployeeAsync(int Id)
        {
            try
            {
                await employeeRepositoty.DeleteEmployeeAsync(Id);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }

    }
}
