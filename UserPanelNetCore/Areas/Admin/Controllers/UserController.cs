

using AutoMapper;
using BaseLayer.Model;
using Entities.ViewModel.Identity.UserVM;
using Entities.ViewModel.PagerVM;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.ConsumeService.Identity.Abstract;
using Service.FluentValidation.Identity.UserValidation;

namespace Tracker.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserConsumeService _userConsumeService;
        private readonly IMapper _mapper;


        private readonly IValidator<UserAddVM> _addValidation;
        private readonly IValidator<UserUpdateVM> _updateValidation;

        public UserController(IUserConsumeService userConsumeService, IMapper mapper, IValidator<UserAddVM> addValidation, IValidator<UserUpdateVM> updateValidation)
        {
            _userConsumeService = userConsumeService;
            _mapper = mapper;
            _addValidation = addValidation;
            _updateValidation = updateValidation;
        }

        public IActionResult Index(int CurrentPageCount)
        {
            PagingVM pager = new PagingVM();
            pager.Paging = new PagerModel();

            var consumePaging = new PagingVM();
            consumePaging.Paging = new PagerModel();    
            consumePaging= _userConsumeService.GetUser(CurrentPageCount);
           


            pager.userListVM= consumePaging.userListVM;
            pager.Paging.CurrentPageCount = consumePaging.Paging!.CurrentPageCount;
            pager.Paging.PagingCount=consumePaging.Paging!.PagingCount; 

            return View(pager);
        }


        [HttpGet]
        [Route("[action]")]
        public IActionResult Details(string id)
        {
            var userUpdateVM = _userConsumeService.GetUserById(id);
            var userListVm= _mapper.Map<UserListVM>(userUpdateVM);
            return View(userListVm);

        }



        [HttpGet]
        public IActionResult Create()
        {
           
            return View();

        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult Edit(string id)
        {


            var userUpdateVM = _userConsumeService.GetUserById(id);
            return View(userUpdateVM);
        }





        [HttpPost]
        public async Task<IActionResult> CreateAsync(UserAddVM request)
        {
            var result = await _addValidation.ValidateAsync(request);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                return View("Create",request);
            }

            request.Id = Guid.NewGuid().ToString();
            var showUserRole = _userConsumeService.AddUser(request);
            return Redirect(nameof(Index));
        }
       
        
        [HttpPost]
        public async Task<IActionResult> UpdateAsync(UserUpdateVM request)
        {
            var result = await _updateValidation.ValidateAsync(request);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                return View("Edit", request);
            }
            if (User.Identity!.Name != "superAdmin")
            {
                ViewData["error"] = "error";
                ModelState.AddModelError("", "you are not authorized for this action");
                return View("Edit", request);

            }

            var showUserRole = _userConsumeService.UpdateUser(request);
            return Redirect(nameof(Index));
        }




        // fot user assign role

        [HttpGet]
        [Route("[action]")]
        public IActionResult ShowUserRole(string userId)
        {
        var showUserRole=  _userConsumeService.ShowUserRole(userId);   
            return View(showUserRole);
        }

        [HttpPost]
        public IActionResult AssignRoles(UserAssignRoleVM role)
        { 
           _userConsumeService.AssignRoles(role);
            return  RedirectToAction(nameof(Index));
        }
    }
}
