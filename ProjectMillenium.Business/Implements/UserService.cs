using AutoMapper;
using ProjectMillenium.Business.Interfaces;
using ProjectMillenium.Core.Entities;
using ProjectMillenium.Core.Entity;
using ProjectMillenium.Core.Exceptions;
using ProjectMillenium.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMillenium.Business.Implements
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserRoleRepository _userRoleRepository;

        public UserService(IUserRepository userRepository, IUserRoleRepository userRoleRepository)
        {
            _userRepository = userRepository;

            _userRoleRepository = userRoleRepository;
        }



        public void Create(User user)
        {
            var recordedUser = _userRepository.GetByEmail(user.Email);


            if (recordedUser != null)
            {
                throw new BusinessException("Bu email başka bir kullanıcıya aittir.");
            }


            _userRepository.Create(user);

        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }


        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public User GetByUserName(string userName)
        {
            return _userRepository.GetByUserName(userName);
        }

        public User GetByEmail(string email)
        {
            return _userRepository.GetByEmail(email);
        }

        public void Delete(User user)
        {
            _userRepository.Delete(user);

        }

        public void Edit(User user)
        {

            _userRepository.Edit(user);
        }

        public List<UserRole> GetUserRoles(User user)
        {
            return _userRoleRepository.GetUserRoles(user).ToList();
        }
        public List<User> GetActiveUsers(bool isActive)
        {
            return _userRepository.GetActiveUsers(isActive).ToList();
        }

        public void AddUserRole(UserRole userRole)
        {
            _userRoleRepository.Create(userRole);
        }

        public bool UserHasRole(int userId, int roleId)
        {
            var userRoles = _userRoleRepository.GetAllUserRoles(userId);

            return userRoles.Any(role => role.RoleId == roleId);
        }


        public List<UserRole> GetAllUserRoles(int userId)
        {
            return _userRoleRepository.GetAllUserRoles(userId).ToList();
        }

        public List<UserRole> GetUserRolesExceptUser(User user)
        {
            return _userRoleRepository.GetUserRolesExceptUser(user);
        }

        public void RemoveUserRole(int userId, int roleId)
        {
           
           var userRole=_userRoleRepository.GetUserRoleById(userId, roleId);
           
           _userRoleRepository.Delete(userRole);
        }
    }
}
