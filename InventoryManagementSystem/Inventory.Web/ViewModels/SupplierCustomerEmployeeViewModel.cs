
using System.ComponentModel.DataAnnotations;

namespace Inventory.Web.ViewModels
{
    public class SupplierCustomerEmployeeViewModel
    {
        public int SupplierID { get; set; }

        [Required(ErrorMessage = "Supplier Name Cannot be Empty.")]
        [StringLength(100, ErrorMessage = "Name Should be Under 100 Characters.")]
        public string? SupplierName { get; set; }

        [Required(ErrorMessage = "Phone Number Cannot be Empty.")]
        [StringLength(15, ErrorMessage = "Phone Number Should be Under 15 Characters.")]
        public string? PhoneNumber { get; set; }

        [StringLength(30, ErrorMessage = "Email Should be Under 30 Characters.")]
        public string? Email { get; set; }

        [StringLength(9, ErrorMessage = "Other Details Should be 9 Characters.")]
        public string? PanNumber { get; set; }
        public int? AddressId { get; set; }

        [StringLength(150, ErrorMessage = "The Length of Country Name should be under 150 characters.")]
        public string? Country { get; set; }

        [Required(ErrorMessage = "City Name Cannot be null.")]
        [StringLength(250, ErrorMessage = "The Length of City Name should be under 250 characters.")]
        public string? City { get; set; }

        [Required(ErrorMessage = "Local Address Cannot be null.")]
        [StringLength(550, ErrorMessage = "The Length of Local Address should be under 550 characters.")]
        public string? LocalAddress { get; set; }

        // for employee 
        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "Employee Name Cannot be Empty.")]
        [StringLength(100, ErrorMessage = "Name Should be Under 100 Characters.")]
        public string? EmployeeName { get; set; }

        [Required(ErrorMessage = "Email Name Cannot be Empty.")]
        [StringLength(30, ErrorMessage = "Email Should be Under 30 Characters.")]
        public string? EmployeeEmail { get; set; }

        [Required(ErrorMessage = "Post Cannot be Empty.")]
        [StringLength(100, ErrorMessage = "Post Should be Under 100 Characters.")]
        public string? Post { get; set; }

        [Required(ErrorMessage = "Joining Date Cannot be Empty.")]
        public DateTime? DateFoJoining { get; set; }

        [Required(ErrorMessage = "Salary Cannot be Empty.")]
        [Range(0, int.MaxValue, ErrorMessage ="Salary Amount cannot be Negative.")]
        public decimal? CurrentSalary { get; set; }

        public string? Image { get; set; }
    }
}
