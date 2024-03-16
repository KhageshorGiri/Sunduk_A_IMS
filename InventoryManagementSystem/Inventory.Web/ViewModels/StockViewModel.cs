namespace Inventory.Web.ViewModels
{
    public class StockViewModel
    {
        public int ProductId { get; set; }
        public string? ProductCode { get; set; }
        public string? ProductName { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public int Quantity { get; set; }
        public int SoldQuantity { get; set; }
        public decimal Rate { get; set; }
    }
}
