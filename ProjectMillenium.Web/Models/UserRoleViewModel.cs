using ProjectMillenium.Core.Entities;
using ProjectMillenium.Core.Entity;
using System.ComponentModel.DataAnnotations;

namespace ProjectMillenium.Web.Models
{
    public class UserRoleViewModel
    {

        public int UserId { get; set; }
      

        public List<Role> allRoles { get; set; }
        public List<Role> UserRoles { get; set; }

    }

}

