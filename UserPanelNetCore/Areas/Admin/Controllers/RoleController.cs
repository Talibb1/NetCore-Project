

using AutoMapper;
using Entities.ViewModel.Identity.RoleVM;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Service.ConsumeService.Identity.Abstract;

namespace Tracker.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly IRoleConsumeService  _roleConsumeService;

        private readonly IValidator<RoleAddVM> _addValidator;
        private readonly IValidator<RoleUpdateVM> _updateValidator;

        private readonly IMapper _mapper;

        public RoleController(IRoleConsumeService roleConsumeService, IValidator<RoleAddVM> addValidator, IValidator<RoleUpdateVM> updateValidator, IMapper mapper)
        {
            _roleConsumeService = roleConsumeService;
            _addValidator = addValidator;
            _updateValidator = updateValidator;
            _mapper = mapper;
        }



        public  IActionResult Index()
        {
   
           var roleList=  _roleConsumeService.GetRole();
            return View(roleList);
        }



        public IActionResult Details(string Id)
        {
           var role= _roleConsumeService.GetRoleById(Id);
            var roleUpdate = _mapper.Map<RoleUpdateVM>(role);
            return View("Details", roleUpdate);
        }


        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }


        [HttpGet]
        public IActionResult Deletes(string id)
        {
            var role = _roleConsumeService.GetRoleById(id);
            return View("Delete", role);
            
        }


        [HttpPost]
        public async Task<IActionResult> Create(RoleAddVM request)
        {
            var result = await _addValidator.ValidateAsync(request);
            if (!result.IsValid)
            {

                result.AddToModelState(this.ModelState);
                return View(request);
            }
            _roleConsumeService.Create(request);
            return RedirectToAction(nameof(Index));
        }
            

        [HttpPost]
        public async Task<IActionResult> Update(RoleUpdateVM request)
        {
            var result = await  _updateValidator.ValidateAsync(request);
            if (!result.IsValid)
            {

                result.AddToModelState(this.ModelState);
                return View("Details",request);
            }
            _roleConsumeService.Update(request);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
         public IActionResult DeleteRole(string Id)
        {
            var role= _roleConsumeService.GetRoleById(Id);
          
            return View("Delete", role);
        }


        [HttpPost]
        public IActionResult Delete(string Id)
        {
             _roleConsumeService.Delete(Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
