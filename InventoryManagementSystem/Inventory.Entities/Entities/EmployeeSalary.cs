using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Entities.Entities
{
    public class EmployeeSalary
    {
        [Key]
        public int SalaryId { get; set; }

        [Required(ErrorMessage = "Salary Amount Cannot be Empty.")]
        [Range(0, int.MaxValue, ErrorMessage ="Salary Amount Canno tbe Negative.")]
        public decimal? SalaryAmount { get; set; }

        [Required(ErrorMessage = "Status Vaule Cannot be Empty.")]
        public bool ActiveStatus { get; set; }

        // adding relationship with employee
        public virtual Employee? Employee { get; set; }
        public int? EmployeeId { get; set; }

    }
}
