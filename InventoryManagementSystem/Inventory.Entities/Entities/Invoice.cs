using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Entities.Entities
{
    public class Invoice
    {
        [Key]
        public int InvoiceBillId { get; set; }

        [Required(ErrorMessage = "BillNumber Name Cannot be Empty.")]
        [Range(1, Int32.MaxValue, ErrorMessage = "BillNumber Should Be a Positive Value.")]
        public string? BillNumber { get; set; }

        [Required(ErrorMessage = "BillNumber Name Cannot be Empty.")]
        [DataType(DataType.DateTime, ErrorMessage = "Data Should Be In Correct Format.")]
        public DateTime? BillIssueDate { get; set; }

        [Required(ErrorMessage = "Voucher Date Cannot be Empty.")]
        [DataType(DataType.DateTime, ErrorMessage = "Voucher Date Should Be In Correct Format.")]
        public DateTime? VoucherDate { get; set; }

        [Required(ErrorMessage = "Sell Date Name Cannot be Empty.")]
        [DataType(DataType.DateTime, ErrorMessage = "Sell Date Should Be In Correct Format.")]
        public string? SellDate { get; set; }

        [Required(ErrorMessage = "BillNumber Name Cannot be Empty.")]
        [StringLength(200, ErrorMessage = "Comment Should Be Under 200 Characters.")]
        public string? Comment { get; set; }


        // adding relationship with other tables
        public List<Product>? Products { get; set; }

        public int? CustomerID { get; set; }
        public virtual Customer? Customer { get; set; }
    }
}
