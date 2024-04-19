using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMillenium.Core.Entities
{
    public class Claim:EntityBase
    {

        [Required]
        [DisplayName("Name")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Description")]
        [StringLength(100, ErrorMessage = "Description cannot be longer than 50 characters.")]
        public string Description { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public ICollection<RoleClaim> RoleClaims { get; set; }

    }
}
