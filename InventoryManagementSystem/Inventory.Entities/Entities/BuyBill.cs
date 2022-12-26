
using System.ComponentModel.DataAnnotations;

namespace Inventory.Entities.Entities
{
    public class BuyBill
    {
        public BuyBill()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        public int BillId { get; set; }

        [Required(ErrorMessage = "BillNumber Name Cannot be Empty.")]
        [Range(1, Int32.MaxValue, ErrorMessage = "BillNumber Should Be a Positive Value.")]
        public string? BillNumber { get; set; }

        [Required(ErrorMessage = "BillNumber Name Cannot be Empty.")]
        [DataType(DataType.DateTime, ErrorMessage = "Data Should Be In Correct Format.")]
        public DateTime? BillDate { get; set; }

        // adding relationship with other tables
        public virtual ICollection<Product> Products { get; set; }
    }
}
