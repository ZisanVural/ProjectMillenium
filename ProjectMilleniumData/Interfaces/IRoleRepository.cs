using ProjectMillenium.Core.Entities;
using ProjectMillenium.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMillenium.Data.Interfaces
{
    public interface IRoleRepository : IRepository<Role>
    {
        Role GetByName(string roleName);
        List<Role> GetActiveRoles(bool isActive);
    }
}

