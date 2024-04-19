using ProjectMillenium.Core.Entities;
using ProjectMillenium.Core.Entity;
using ProjectMillenium.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMillenium.Business.Interfaces
{
    public interface IUserService
    {
        void Create(User Entity);
       
        void Delete(User Entity);
        void Edit(User Entity);
        void AddUserRole(UserRole Entity);
        User GetByUserName(string userName);
        void RemoveUserRole(int userId, int roleId);
        List<UserRole> GetUserRoles(User Entity);
        List<UserRole> GetUserRolesExceptUser(User Entity);
        List<User> GetActiveUsers(bool isActive);
        List<UserRole> GetAllUserRoles(int userId);       
        bool UserHasRole(int userId, int roleId);
        User GetById(int id);
        User GetByEmail(string email);
        List<User> GetAll();

    }
}