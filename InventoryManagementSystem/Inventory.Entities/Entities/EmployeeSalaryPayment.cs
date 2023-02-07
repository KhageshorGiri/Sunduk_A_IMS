using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Entities.Entities
{
    public class EmployeeSalaryPayment
    {
        [Key]
        public int PaymentID { get; set; }

        [Required(ErrorMessage = "Amount Cannot be Empty.")]
        [Range(0, int.MaxValue, ErrorMessage = "Amount Canno tbe Negative.")]
        public decimal? PayedAmount { get; set; }

        [Required(ErrorMessage = "Payment Date Cannot be Empty.")]
        public DateTime PaymentDate { get; set; }

        //public int PayedMy

        [Required(ErrorMessage = "Salary Amount Cannot be Empty.")]
        [StringLength(200, ErrorMessage = "Remarks should be under 250 characters.")]
        public string? Remarks { get; set; }

        // adding relationship with employee
        public virtual Employee? Employee { get; set; }
        public int? EmployeeId { get; set; }
    }
}
