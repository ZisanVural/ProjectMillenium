using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectMillenium.Business.Implements;
using ProjectMillenium.Business.Interfaces;
using ProjectMillenium.Core.Entities;
using ProjectMillenium.Core.Entity;
using ProjectMillenium.Core.Exceptions;
using ProjectMillenium.Data.Interfaces;
using ProjectMillenium.Web.Models;

namespace ProjectMillenium.Web.Controllers
{
    public class RoleController : Controller
    {
        private readonly ILogger <RoleController> _logger;   
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;
        private readonly IClaimService _claimService;
      
        public RoleController(ILogger<RoleController> logger, IRoleService roleService, IMapper mapper, IClaimService claimService)
        {
            _logger = logger;
            _roleService = roleService;
            _mapper = mapper;
            _claimService= claimService;
        }

        [HttpGet]
        public async Task< IActionResult> Index()
        {
            var roles = _roleService.GetAll();
            var roleViewModel = _mapper.Map<List<RoleViewModel>>(roles);

            return View(roleViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> AddRoleClaims(int id)
        {
            var role = _roleService.GetById(id);

            if (role == null)
            {
                return BadRequest("Kullanıcı bulunamadı!");
            }

            var allClaims = _claimService.GetAll();
           
            var claimRoles = _roleService.GetRoleClaims(role).Select(x=> x.Claim).ToList();

            var availableRoles = allClaims.Where(x => !claimRoles.Select(y => y.Name).Contains(x.Name)).ToList();

            var model = new RoleClaimViewModel
            {
                allClaims = availableRoles,
                RoleClaims= claimRoles,
                RoleId = id
            };

            return View(model);
            
        }

        [HttpPost]

        public IActionResult AddRoleClaim(int roleId, List<int> claims)
        {
            var role = _roleService.GetById(roleId);

            if (role == null)
            {
                return BadRequest("Kullanıcı bulunamadı!");
            }
            foreach (var claimId in claims)
            {
                var roleClaims = new RoleClaim()
                {
                    Claim = _claimService.GetById(claimId),
                    Role=role
                };

                _roleService.AddRoleClaim(roleClaims);
            }

            return RedirectToAction("AddRoleClaims");

        }



        [HttpGet]
        public async Task<IActionResult> Create()

        {
            return View();
          
        }

        [HttpPost]

        public async Task<IActionResult>Create(int id, [Bind("Name, Description")] RoleViewModel roleModel )
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var role = _mapper.Map<Role>(roleModel);
                    role.IsActive = true;
                    _roleService.Create(role);
                    return RedirectToAction(nameof(Index));
                }
                return View(roleModel);
            }
            catch (BusinessException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(roleModel);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(roleModel);
            }

        }



        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var role = _roleService.GetById(id);

            if (role == null)
            {

                return NotFound();
            }

            RoleViewModel roleModel = _mapper.Map<RoleViewModel>(role);
            return View(roleModel);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Description")] Role role)
        {

            try
            {

                if (id == 0)
                {
                    return NotFound();
                }

                var recordedRole = _roleService.GetById(id);

                if (recordedRole == null)
                {
                    return NotFound();
                }

                recordedRole.Name = role.Name;
                recordedRole.Description = role.Description;
                recordedRole.IsActive = role.IsActive;
                _roleService.Update(recordedRole);
            }

            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Edit", role);
            }
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var role = _roleService.GetById(id);

            if (role == null)
            {

                return NotFound();
            }

            RoleViewModel roleModel = _mapper.Map<RoleViewModel>(role);
            return View(roleModel);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteRole(int id)
        {
            try
            {

                if (id == 0)
                {
                    return NotFound();
                }

                var recordedRole = _roleService.GetById(id);


                if (recordedRole == null)
                {
                    return NotFound();
                }


                if (recordedRole != null)
                {
                    _roleService.Delete(recordedRole);

                }

            }

            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Delete", id);
            }

            return RedirectToAction(nameof(Index));


        }



    }
}
