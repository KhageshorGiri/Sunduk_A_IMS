
using System.ComponentModel.DataAnnotations;

namespace Inventory.Entities.Entities
{
    public class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Category Name Cannot be Empty.")]
        [StringLength(50, ErrorMessage = "Category Name Should be Under 50 Characters.")]
        public string? CategoryName { get; set; }

        [Required(ErrorMessage = "Category Description Cannot be Empty.")]
        [StringLength(100, ErrorMessage = "Category Description Should be Under 100 Characters.")]
        public string? Description { get; set; }

        // adding relationship with other tables.
        public virtual ICollection<Product> Products { get; set; }
    }
}
