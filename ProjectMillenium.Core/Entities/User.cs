using ProjectMillenium.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMillenium.Core.Entity
{
    public class User : EntityBase
    {
       
        [Required]
        [DisplayName("Name")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
         ErrorMessage = "Karakterler uygun değil.")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Lastname")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$")]
        public string Lastname { get; set; }


        [Required]
        [DisplayName("Username")]
        public string Username { get; set; }

        [Required]
        [DisplayName("Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DisplayName("Password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{12}$", ErrorMessage = "Karakterler uygun değil.")]
        public string Password { get; set; } 

        [Required]
        [DisplayName("IsActive")]
        public bool IsActive { get; set; }

        public ICollection<UserRole> UserRoles { get; set; } 

    }
}
