using Microsoft.EntityFrameworkCore;
using ProjectMillenium.Business.Interfaces;
using ProjectMillenium.Core.Entities;
using ProjectMillenium.Core.Entity;
using ProjectMillenium.Data.Implements;
using ProjectMillenium.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMillenium.Business.Implements
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IRoleClaimRepository _roleClaimRepository;

        public RoleService (IRoleRepository roleRepository, IRoleClaimRepository roleClaimRepository)
        {
            _roleRepository = roleRepository;
            _roleClaimRepository = roleClaimRepository;
        }

        public void AddRoleClaim(RoleClaim roleClaim)
        {
            _roleClaimRepository.Create(roleClaim);
        }

        public List<RoleClaim> GetRoleClaims(Role role)
        {
            return _roleClaimRepository.GetRoleClaims(role).ToList();
        }
        
        public List<RoleClaim> GetRoleClaimExceptRole(Role role)
        {
            return _roleClaimRepository.GetRoleClaimsExceptRole(role);

        }

        public void Create(Role role)
        {
          _roleRepository.Create(role);
        }

        public void Delete(Role role)
        {
            _roleRepository.Delete(role);
           
        }

        public void Edit(Role role)
        {
            _roleRepository.Edit(role);
        }

        public List<Role> GetActiveRoles(bool isActive)
        {
            return _roleRepository.GetActiveRoles(isActive).ToList();
        }

        public List<Role> GetAll()
        {
            return _roleRepository.GetAll();    
        }

        public Role GetById(int id)
        {
            return _roleRepository.GetById(id);
        }

        public Role GetByName(string roleName)
        {
             return _roleRepository.GetByName(roleName);
        }

        public void Update(Role role)
        {
            _roleRepository.Edit(role);
        }

      
    }
}
