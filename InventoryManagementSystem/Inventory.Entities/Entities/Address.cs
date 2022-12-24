using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Entities.Entities
{
    public class Address
    {
        public Address()
        {
            Suppliers = new HashSet<Supplier>();
        }

        [Key]
        public int AddressId { get; set; }

        [StringLength(150, ErrorMessage = "The Length of Country Name should be under 150 characters.")]
        public string? Country { get; set; }
        
        [Required(ErrorMessage = "City Name Cannot be null.")]
        [StringLength(250, ErrorMessage = "The Length of City Name should be under 250 characters.")]
        public string? City { get; set; }

        [Required(ErrorMessage = "Local Address Cannot be null.")]
        [StringLength(550, ErrorMessage = "The Length of Local Address should be under 550 characters.")]
        public string? LocalAddress { get; set; }

        // adding the relationship with other tables
        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}
