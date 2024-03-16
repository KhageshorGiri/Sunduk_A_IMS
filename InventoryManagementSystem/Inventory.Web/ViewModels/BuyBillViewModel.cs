using Inventory.Entities.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Web.ViewModels
{
    public class BuyBillViewModel
    {
        public int? BillId { get; set; }

        [Required(ErrorMessage = "BillNumber Name Cannot be Empty.")]
        [Range(1, Int32.MaxValue, ErrorMessage = "BillNumber Should Be a Positive Value.")]
        public string? BillNumber { get; set; }

        [Required(ErrorMessage = "BillNumber Name Cannot be Empty.")]
        [DataType(DataType.DateTime, ErrorMessage = "Data Should Be In Correct Format.")]
        public string? BillIssueDate { get; set; }

        [Required(ErrorMessage = "Voucher Date Cannot be Empty.")]
        [DataType(DataType.DateTime, ErrorMessage = "Voucher Date Should Be In Correct Format.")]
        public string? VoucherDate { get; set; }

        [Required(ErrorMessage = "Purchase Date Name Cannot be Empty.")]
        [DataType(DataType.DateTime, ErrorMessage = "Purchase Date Should Be In Correct Format.")]
        public string? PurchaseDate { get; set; }

        public int? ProductId { get; set; }

        [Required(ErrorMessage = "Product Name Cannot Be Empty.")]
        [StringLength(200, ErrorMessage = "Product Name Should Be Under 200 Characters.")]
        public string? ProductName { get; set; }

        [Required(ErrorMessage = "Product Code Cannot Be Empty.")]
        [StringLength(200, ErrorMessage = "Product Code Should Be Under 200 Characters.")]
        public string? ProductCode { get; set; }

        [Required(ErrorMessage = "Description Cannot Be Empty.")]
        [StringLength(200, ErrorMessage = "Description Should Be Under 200 Characters.")]
        public string? ProductDescription { get; set; }

        [Required(ErrorMessage = "Comment Cannot Be Empty.")]
        [StringLength(200, ErrorMessage = "Comment Should Be Under 200 Characters.")]
        public string? Comment { get; set; }

        [Required(ErrorMessage = "Price Cannot Be Empty.")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Price Should Be a Positive Value.")]
        public decimal? Rate { get; set; } = 0;

        [Required(ErrorMessage = "Quantity Cannot Be Empty.")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Quantity Should Be a Positive Value.")]
        public int Quantity { get; set; }

        // adding relationship with others tables.

        [Required(ErrorMessage = "Unit Cannot Be Empty.")]
        public int UnitId { get; set; }

        [Required(ErrorMessage = "Category Cannot Be Empty.")]
        public int CategoryId { get; set; }
        public int? SupplierID { get; set; }

        public List<ProductList>? Products { get; set; }
    }

    public class ProductList
    {
        public int? ProductId { get; set; }

        [Required(ErrorMessage = "Product Name Cannot Be Empty.")]
        [StringLength(200, ErrorMessage = "Product Name Should Be Under 200 Characters.")]
        public string? ProductName { get; set; }

        [Required(ErrorMessage = "Product Code Cannot Be Empty.")]
        [StringLength(200, ErrorMessage = "Product Code Should Be Under 200 Characters.")]
        public string? ProductCode { get; set; }

        [StringLength(200, ErrorMessage = "Description Should Be Under 200 Characters.")]
        public string? ProductDescription { get; set; }

        [Range(1, Int32.MaxValue, ErrorMessage = "Price Should Be a Positive Value.")]
        public decimal? Rate { get; set; } = 0;

        [Range(1, Int32.MaxValue, ErrorMessage = "Quantity Should Be a Positive Value.")]
        public int Quantity { get; set; }

        public int? BillId { get; set; }
        public int? UnitId { get; set; }
        public int? CategoryId { get; set; }

    }
}
