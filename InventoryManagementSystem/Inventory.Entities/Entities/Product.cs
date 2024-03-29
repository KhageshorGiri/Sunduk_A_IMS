﻿
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Entities.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product Name Cannot Be Empty.")]
        [StringLength(200, ErrorMessage = "Product Name Should Be Under 200 Characters.")]
        public string? ProductName { get; set; }

        [Required(ErrorMessage = "Product Code Cannot Be Empty.")]
        [StringLength(200, ErrorMessage = "Product Code Should Be Under 200 Characters.")]
        public string? ProductCode { get; set; }

        [Required(ErrorMessage = "Description Cannot Be Empty.")]
        [StringLength(200, ErrorMessage = "Description Should Be Under 200 Characters.")]
        public string? ProductDescription { get; set; }

        [Required(ErrorMessage = "Price Cannot Be Empty.")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Price Should Be a Positive Value.")]
        public decimal? Rate { get; set; } = 0;

        [Required(ErrorMessage = "Quantity Cannot Be Empty.")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Quantity Should Be a Positive Value.")]
        public int Quantity { get; set; }

        public int SoldQuantity { get; set; } = 0;
        // adding relationship with others tables.
        [Required]
        //[ForeignKey("BuyBill")]
        public int BillId { get; set; }
        public virtual BuyBill? BuyBill { get; set; }

        [Required(ErrorMessage = "Unit Cannot Be Empty.")]
        public int UnitId { get; set; }
        public virtual Unit? Unit { get; set; }

        [Required(ErrorMessage = "Category Cannot Be Empty.")]
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }


    }
}
