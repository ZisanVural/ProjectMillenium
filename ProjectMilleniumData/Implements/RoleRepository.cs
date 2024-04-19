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
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public RoleRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public List<Role> GetActiveRoles(bool isActive)
        {
            return _context.Set<Role>().Where(x => x.IsActive == isActive).ToList();
        }
      

        public Role GetByName(string roleName)
        {
            return _context.Set<Role>().Where(x => x.Name == roleName).FirstOrDefault();

        }
    
    }
}
