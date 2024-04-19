using ProjectMillenium.Core.Entities;
using ProjectMillenium.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMillenium.Business.Interfaces
{
    public interface IRoleService
    {
        void Create(Role Entity);
        void Update(Role Entity);
        void Delete(Role Entity);
        void Edit(Role Entity);
        void AddRoleClaim(RoleClaim Entity);
        List<RoleClaim> GetRoleClaims(Role Entity);
        List<RoleClaim> GetRoleClaimExceptRole(Role Entity);
        List<Role> GetActiveRoles(bool isActive);
        Role GetById(int id);
        Role GetByName(string roleName);
        List<Role> GetAll();
       
    }
}
