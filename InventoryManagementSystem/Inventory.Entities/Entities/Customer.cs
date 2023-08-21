using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Entities.Entities
{
    public class Customer
    {
        public Customer()
        {
            
        }

        [Key]
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "Customer Name Cannot be Empty.")]
        [StringLength(100, ErrorMessage = "Name Should be Under 100 Characters.")]
        public string? CustomerName { get; set; }

        [Required(ErrorMessage = "Phone Number Cannot be Empty.")]
        [StringLength(15, ErrorMessage = "Phone Number Should be Under 15 Characters.")]
        public string? PhoneNumber { get; set; }

        [StringLength(30, ErrorMessage = "Email Should be Under 30 Characters.")]
        public string? Email { get; set; }

        [StringLength(9, ErrorMessage = "Other Details Should be 9 Characters.")]
        public string? PanNumber { get; set; }

        [StringLength(200, ErrorMessage = "Other Details Should be Under 100 Characters.")]
        public string? OtherDetails { get; set; }

        // Adding the relationship to others table
        public int? AddressId { get; set; }
        public Address? Address { get; set; }

    }
}
