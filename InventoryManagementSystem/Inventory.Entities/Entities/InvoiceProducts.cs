using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Entities.Entities
{
    public class InvoiceProducts
    {
        public int? InvoiceProductsId { get; set; }

        public int? StockProductId { get; set; }

        [Range(1, Int32.MaxValue, ErrorMessage = "Price Should Be a Positive Value.")]
        public decimal? Rate { get; set; } = 0;

        [Range(1, Int32.MaxValue, ErrorMessage = "Quantity Should Be a Positive Value.")]
        public int? Quantity { get; set; }

        public int? InvoiceBillId { get; set; }
        public virtual Invoice? Invoice { get; set; }
    }
}
