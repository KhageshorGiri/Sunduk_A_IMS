using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Entities.Entities
{
    public class Users : IdentityUser<string>
    {
        
        [Required(ErrorMessage = "Name value cannot be empty.")]
        [MaxLength(300)]
        public string? Name { get; set; }

        [NotMapped]
        public string? DisplayRole { get; set; }
    }
}
