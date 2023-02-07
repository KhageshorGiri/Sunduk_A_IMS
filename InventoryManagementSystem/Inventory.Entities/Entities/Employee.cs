using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Entities.Entities
{
    public class Employee
    {
        public Employee()
        {
            EmployeeSalaries = new HashSet<EmployeeSalary>();
            EmployeeSalaryPaments = new HashSet<EmployeeSalaryPayment>();
        }

        [Key]
        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "Employee Name Cannot be Empty.")]
        [StringLength(100, ErrorMessage = "Name Should be Under 100 Characters.")]
        public string? EmployeeName { get; set; }

        [Required(ErrorMessage = "Post Cannot be Empty.")]
        [StringLength(100, ErrorMessage = "Post Should be Under 100 Characters.")]
        public string? Post { get; set; }

        [Required(ErrorMessage = "Phone Number Cannot be Empty.")]
        [StringLength(15, ErrorMessage = "Phone Number Should be of 15 Characters.")]
        public string? PhoneNumber { get; set; }

        [StringLength(30, ErrorMessage = "Email Should be Under 30 Characters.")]
        public string? Email { get; set; }

        [StringLength(9, ErrorMessage = "Other Details Should be 9 Characters.")]
        public string? PanNumber { get; set; }

        public DateTime? DateFoJoining { get; set; }

        // Adding the relationship to others table
        public int? AddressId { get; set; }
        public Address? Address { get; set; }

        public virtual ICollection<EmployeeSalary> EmployeeSalaries { get; set; }
        public virtual ICollection<EmployeeSalaryPayment> EmployeeSalaryPaments { get; set; }
    }
}
