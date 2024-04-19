using ProjectMillenium.Core.Entities;

namespace ProjectMillenium.Web.Models
{
    public class RoleClaimViewModel
    {
        public int RoleId { get; set; }

        public List<Claim> allClaims { get; set; }
        public List<Claim> RoleClaims { get; set; }
    }
}
