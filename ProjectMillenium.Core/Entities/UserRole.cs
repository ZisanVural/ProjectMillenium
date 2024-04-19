using ProjectMillenium.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMillenium.Core.Entities
{
    public class UserRole
    {

        [Required]
        public int UserId { get; set; }


        [Required]
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public User User { get; set; }

        public override bool Equals(object? obj)
        {
            UserRole userRole = obj as UserRole;

            return userRole.Role.Name == this.Role.Name && userRole.User.Id == this.User.Id;

        }

        public override int GetHashCode()
        {
            return this.Role.Name.GetHashCode();
        }
    }

}
