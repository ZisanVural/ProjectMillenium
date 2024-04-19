using Microsoft.EntityFrameworkCore;
using ProjectMillenium.Core.Entities;
using ProjectMillenium.Core.Entity;
using ProjectMillenium.Data.Context;
using ProjectMillenium.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjectMillenium.Data.Implements
    {
        public class RoleClaimRepository : Repository<RoleClaim>, IRoleClaimRepository
        {
            private readonly ApplicationDbContext _context;

            public RoleClaimRepository(ApplicationDbContext context) : base(context)
            {
                _context = context;
            }

        public RoleClaim GetByName(string roleClaimName)
        {
            return _context.Set<RoleClaim>().Where(x => x.RoleClaimName == roleClaimName).FirstOrDefault();

        }

        public List<RoleClaim> GetRoleClaimsExceptRole(Role role)
        {
            return _context.Set<RoleClaim>().Where(x => x.Role != role).ToList();
        }

        public List<RoleClaim> GetRoleClaims(Role role)
        {
            var list = _context.Set<RoleClaim>().Include(x => x.Role).Where(u => u.Role.Id == role.Id).ToList();

            return list;
        }

        public RoleClaim GetRoleClaimById(int roleId, int claimId)
        {
            return _context.Set<RoleClaim>().Where(x => x.RoleId == roleId && x.ClaimId == claimId).FirstOrDefault();
        }


    }
}




    

