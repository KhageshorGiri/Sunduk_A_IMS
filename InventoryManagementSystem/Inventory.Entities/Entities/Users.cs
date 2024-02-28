using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Entities.Entities
{
    public class Users : IdentityUser<string>
    {
        [Key]
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "Name value cannot be empty.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Eail value cannot be empty.")]
        [EmailAddress]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password value cannot be empty.")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Conformpassword value cannot be empty.")]
        [Compare(nameof(Password), ErrorMessage = "Password and Conformpassword need to be same.")]
        public string? ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Contact value cannot be null.")]
        public string? Contact { get; set; }

        // realtionship
        public Guid? RoleId { get; set; }
        public virtual Role? Role { get; set; }
    }
}
