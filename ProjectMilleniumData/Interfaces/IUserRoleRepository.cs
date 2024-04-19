using ProjectMillenium.Core.Entities;
using ProjectMillenium.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMillenium.Data.Interfaces
{
    public interface IUserRoleRepository : IRepository<UserRole>
    {

        List<UserRole> GetUserRoles(User user);
        List<UserRole> GetUserRolesExceptUser(User user);
        List<UserRole> GetAllUserRoles(int userId);
        UserRole GetUserRoleById(int userId, int roleId);

    }
}
