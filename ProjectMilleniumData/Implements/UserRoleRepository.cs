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
    public class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRoleRepository(ApplicationDbContext context): base (context)
        {
            _context = context;
        }


        public List<UserRole> GetUserRoles(User user)
        {
            var list= _context.Set<UserRole>().Include(x => x.Role).Where(u=>u.User.Id==user.Id).ToList();

            return list;
        }

        public List<UserRole> GetUserRolesExceptUser(User user)
        {
            return _context.Set<UserRole>().Where(x => x.User != user).ToList();
        }

        public List<UserRole> GetAllUserRoles(int userId)
        {
            return _context.Set<UserRole>().Where(x => x.UserId == userId).ToList();

        }

        public UserRole GetUserRoleById(int userId, int roleId) 
        {
            return _context.Set<UserRole>().Where(x => x.UserId == userId &&  x.RoleId==roleId).FirstOrDefault();
        }

       
    }

       
    }

