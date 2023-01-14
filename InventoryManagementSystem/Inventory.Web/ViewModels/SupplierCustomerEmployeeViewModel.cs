
namespace Inventory.Web.ViewModels
{
    public class SupplierCustomerEmployeeViewModel
    {
        public int SupplierID { get; set; }
        public string? SupplierName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? PanNumber { get; set; }
        public string? OtherDetails { get; set; }
        public int? AddressId { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? LocalAddress { get; set; }
    }
}
