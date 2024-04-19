using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectMillenium.Business.Implements;
using ProjectMillenium.Business.Interfaces;
using ProjectMillenium.Core.Entities;
using ProjectMillenium.Core.Exceptions;
using ProjectMillenium.Web.Models;

namespace ProjectMillenium.Web.Controllers
{
    public class ClaimController : Controller
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IClaimService _claimService;
        
        public ClaimController(ILogger<ClaimController> logger, IClaimService claimService, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _claimService = claimService;
        }
        
        [HttpGet]
        public async Task< IActionResult>Index()
        {
            var claims = _claimService.GetAll();
            var claimViewModel = _mapper.Map<List<ClaimViewModel>>(claims);

            return View(claimViewModel);
        }

        [HttpGet]   
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(int id, [Bind("Name, Description")] ClaimViewModel claimModel)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var claim = _mapper.Map<Claim>(claimModel);
                    claim.IsActive = true;
                    _claimService.Create(claim);

                    return RedirectToAction(nameof(Index));
                }
                return View(claimModel);
            }
            catch (BusinessException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(claimModel);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(claimModel);
            }


        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var claim = _claimService.GetById(id);

            if (claim == null)
            {

                return NotFound();
            }

            ClaimViewModel claimModel = _mapper.Map<ClaimViewModel>(claim);
            return View(claimModel);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Description")] Claim claim)
        {

            try
            {

                if (id == 0)
                {
                    return NotFound();
                }

                var recordedClaim = _claimService.GetById(id);

                if (recordedClaim == null)
                {
                    return NotFound();
                }

                recordedClaim.Name = claim.Name;
                recordedClaim.Description = claim.Description;
                recordedClaim.IsActive = claim.IsActive;
                _claimService.Edit(recordedClaim);
            }

            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return RedirectToAction("Edit", claim);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var claim = _claimService.GetById(id);

            if (claim == null)
            {

                return NotFound();
            }

            ClaimViewModel claimModel = _mapper.Map<ClaimViewModel>(claim);
            return View(claimModel);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteClaim(int id)
        {
            try
            {

                if (id == 0)
                {
                    return NotFound();
                }

                var recordedClaim = _claimService.GetById(id);


                if (recordedClaim == null)
                {
                    return NotFound();
                }


                if (recordedClaim != null)
                {
                    _claimService.Delete(recordedClaim);

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
