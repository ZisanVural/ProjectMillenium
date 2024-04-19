using ProjectMillenium.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMillenium.Data.Interfaces
{
    public interface IRoleClaimRepository :IRepository<RoleClaim>
    {
        RoleClaim GetByName(string roleClaimName);
        List<RoleClaim> GetRoleClaims(Role role);
        RoleClaim GetRoleClaimById(int roleId, int claimId);
        List<RoleClaim> GetRoleClaimsExceptRole(Role role);
    }
}
