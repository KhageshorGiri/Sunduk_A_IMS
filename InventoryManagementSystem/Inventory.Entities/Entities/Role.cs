using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Entities.Entities
{
    public class Role : IdentityRole<string>
    {
        public Role()
        {
            Users = new HashSet<Users>();
        }

        [Key]
        public Guid RoleID { get; set; }

        [Required(ErrorMessage = "Role value cannot be empty.")]
        public string? RoleType { get; set; }

        public virtual IEnumerable<Users>? Users { get; set; }
    }
}
