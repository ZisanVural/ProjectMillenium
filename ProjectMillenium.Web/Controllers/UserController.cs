using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectMillenium.Business.Implements;
using ProjectMillenium.Business.Interfaces;
using ProjectMillenium.Core.Entities;
using ProjectMillenium.Core.Entity;
using ProjectMillenium.Core.Exceptions;
using ProjectMillenium.Data.Context;
using ProjectMillenium.Web.Models;
using System.CodeDom;
using System.Data;
using System.Linq;

namespace ProjectMillenium.Web.Controllers
{
    public class UserController : Controller

    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IRoleService _roleService;


        public UserController(IMapper mapper, IUserService userService, ILogger<UserController> logger, IRoleService roleService)
        {
            _mapper = mapper;
            _userService = userService;
            _logger = logger;
            _roleService = roleService;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = _userService.GetAll();
            var userViewModel = _mapper.Map<List<UserViewModel>>(users);

            return View(userViewModel);
        }


        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }




        [HttpPost]
        public async Task<IActionResult> Login([Bind("UserName, Password")] User user)
        {

            ModelState.AddModelError(string.Empty, "Invalid username or password");

            var luser = _userService.GetByUserName(user.Name);
            if (luser == null)
            {
                return BadRequest();
            }
            if (luser.Password == user.Password)
            {

                return RedirectToAction("Index", "Home");
            }


            ModelState.AddModelError(string.Empty, "Invalid username or password");
            return View(user);
        }



        [HttpGet]
        public async Task<IActionResult> Create()
        {

            return View();

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name, Lastname, Username, Email, Password")] UserViewModel userModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = _mapper.Map<User>(userModel);
                    user.IsActive = true;
                    _userService.Create(user);
                    return RedirectToAction(nameof(Index));
                }
                return View(userModel);
            }
            catch (BusinessException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(userModel);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(userModel);
            }
        }



        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var user = _userService.GetById(id);

            if (user == null)
            {

                return NotFound();
            }

            UserViewModel userModel = _mapper.Map<UserViewModel>(user);
            return View(userModel);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Lastname,Username,Email")] User user)
        {

            try
            {

                if (id == 0)
                {
                    return NotFound();
                }

                var recordedUser = _userService.GetById(id);

                if (recordedUser == null)
                {
                    return NotFound();
                }

                recordedUser.Email = user.Email;
                recordedUser.Name = user.Name;
                recordedUser.Lastname = user.Lastname;
                recordedUser.Username = user.Username;
                _userService.Edit(recordedUser);
            }

            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Edit", user);
            }
            return RedirectToAction(nameof(Index));
        }




        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var user = _userService.GetById(id);

            if (user == null)
            {

                return NotFound();
            }

            UserViewModel userModel = _mapper.Map<UserViewModel>(user);
            return View(userModel);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {

                if (id == 0)
                {
                    return NotFound();
                }

                var recordedUser = _userService.GetById(id);


                if (recordedUser == null)
                {
                    return NotFound();
                }


                if (recordedUser != null)
                {
                    _userService.Delete(recordedUser);

                }

            }

            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Delete", id);
            }

            return RedirectToAction(nameof(Index));


        }

        [HttpGet]
        public async Task<IActionResult> AddUserRole(int id)
        {

            var user = _userService.GetById(id);

            if (user == null)
            {
                return BadRequest("Kullanıcı bulunamadı!");
            }

            var allRoles = _roleService.GetAll();
            var userRoles = _userService.GetUserRoles(user).Select(x => x.Role).ToList();

            var availableRoles = allRoles.Where(x => !userRoles.Select(y => y.Name).Contains(x.Name)).ToList();

            var model = new UserRoleViewModel
            {
                allRoles = availableRoles,
                UserRoles = userRoles,
                UserId = id
            };

            return View(model);
        }



        [HttpPost]
        public IActionResult AddUserRole(int userId, List<int> roles)
        {
            //userRoles nesnesi yapıp metot ekle user id role list
            var user = _userService.GetById(userId);

            if (user == null)
            {
                return BadRequest("Kullanıcı bulunamadı!");
            }
            foreach (var roleId in roles)
            {
                var userRole = new UserRole()
                {
                    Role = _roleService.GetById(roleId),
                    User = user
                };

                _userService.AddUserRole(userRole);
            }

            return RedirectToAction("AddUserRole");

        }

        [HttpGet]
        public IActionResult RemoveUserRole(int id)
        {
            var user = _userService.GetById(id);

            if (user == null)
            {
                return BadRequest("Kullanıcı bulunamadı!");
            }

            var allRoles = _roleService.GetAll();
            var userRoles = _userService.GetUserRoles(user).Select(x => x.Role).ToList();

            var availableRoles = allRoles.Where(x => !userRoles.Select(y => y.Name).Contains(x.Name)).ToList();

            var model = new UserRoleViewModel
            {
                allRoles = availableRoles,
                UserRoles = userRoles,
                UserId = id
            };


            return View(model);
        }

        [HttpPost]
        public IActionResult RemoveUserRole(int userId, List<int> roles)
        {
            var userRole = _userService.GetById(userId);
            try
            {
                if (userRole != null)
                {
                    foreach (var roleId in roles)
                    {
                        var role = _roleService.GetById(roleId);
                        if (role != null)
                        {
                          
                            if (_userService.UserHasRole(userId, role.Id))
                            {
                                _userService.RemoveUserRole(userId, role.Id);
                            }

                        }
                        
                    }
                    return Json(new { success = true, message = "Roller başarıyla kaldırıldı." });
                }


                else

                    return Json(new { success = false, message = "Kullanıcı bulunamadı." });
            }


            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
        public async Task<IActionResult> Privacy()
        {
            return View();
        }
    }
}











































//var roles = _roleService.GetAll();

//var userRoles = _userService.GetUserRoles(user).Select(x => x.Role).ToList();
//roles = roles.Except(userRoles).ToList();


//UserRoleViewModel model = _mapper.Map<List<UserRoleViewModel>(user);
