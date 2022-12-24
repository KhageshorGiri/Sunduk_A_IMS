using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Entities.Entities
{
    public class Unit
    {
        public Unit()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        public int? UnitId { get; set; }

        [Required(ErrorMessage = "Unit Name Cannot Be Empty.")]
        [StringLength(15, ErrorMessage = "Unit Name Should Be Under 10 Characters.")]
        public string? UnitName { get; set; }

        [Required(ErrorMessage = "Short Form Cannot Be Empty.")]
        [StringLength(5, ErrorMessage = "Short Form Should Be Under 5 Characters.")]
        public string? ShortForm { get; set; }

        // adding relationship with other tables

        public virtual ICollection<Product> Products { get; set; }
    }
}
