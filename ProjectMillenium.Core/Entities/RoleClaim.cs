using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMillenium.Core.Entities
{
    public class RoleClaim:EntityBase
    {
        [Required]
        [Key]
        public int RoleClaimId { get; set; }

        public string RoleClaimName { get; set; }   
        [Required]
        public int RoleId { get; set; }
       
        [Required]
        public int ClaimId { get; set; }
        public Claim Claim { get; set; }
        public Role Role { get; set; }


    }
}
