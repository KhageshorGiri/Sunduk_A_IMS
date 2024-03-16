
using System.ComponentModel.DataAnnotations;

namespace Inventory.Entities.Entities
{
    public class BuyBill
    {
        [Key]
        public int BillId { get; set; }

        [Required(ErrorMessage = "BillNumber Name Cannot be Empty.")]
        [Range(1, Int32.MaxValue, ErrorMessage = "BillNumber Should Be a Positive Value.")]
        public string? BillNumber { get; set; }

        [Required(ErrorMessage = "BillNumber Name Cannot be Empty.")]
        [DataType(DataType.DateTime, ErrorMessage = "Data Should Be In Correct Format.")]
        public DateTime? BillIssueDate { get; set; }

        [Required(ErrorMessage = "Voucher Date Cannot be Empty.")]
        [DataType(DataType.DateTime, ErrorMessage = "Voucher Date Should Be In Correct Format.")]
        public DateTime? VoucherDate { get; set; }

        [Required(ErrorMessage = "Purchase Date Name Cannot be Empty.")]
        [DataType(DataType.DateTime, ErrorMessage = "Purchase Date Should Be In Correct Format.")]
        public DateTime? PurchaseDate { get; set; }

        [Required(ErrorMessage = "BillNumber Name Cannot be Empty.")]
        [StringLength(200, ErrorMessage = "Comment Should Be Under 200 Characters.")]
        public string? Comment { get; set; }


        // adding relationship with other tables
        public List<Product>? Products { get; set; }

        public int? SupplierID { get; set; }
        public virtual Supplier? Supplier { get; set; }
    }
}
