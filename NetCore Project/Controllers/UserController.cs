using BaseLayer.Model;
using Entities.ViewModel.Identity.UserVM;
using Entities.ViewModel.PagerVM;
using Microsoft.AspNetCore.Mvc;
using Service.Service.Identity.Abstract;


namespace NetCore_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("[action]/{CurrentPagerCount?}")]
        [HttpGet]
        public ActionResult<PagingVM> GetUser(int CurrentPagerCount)
        {
            var pagingVM = _userService.GetUserAsync(CurrentPagerCount);
            return pagingVM;
        }


        [Route("[action]/{id?}")]
        [HttpGet]

        public async Task<ActionResult<UserUpdateVM>> GetUserById(string id)
        {
            var userUpdateVM = await _userService.GetUserByIdAsync(id);
            return userUpdateVM;
        }


        [Route("[action]")]
        [HttpPost]
        public async Task<ActionResult<AuthResultApiModel>> Add(UserAddVM request)
        {
            var authResult = await _userService.AddUserAsync(request);
            return authResult;
        }


        [Route("[action]")]
        [HttpPut]
        public async Task<ActionResult<AuthResultApiModel>> Update(UserUpdateVM request)
        {
            var authResult = await _userService.UpdateUserAsync(request);
            return authResult;
        }



        // fot assign user role

        [Route("[action]/{id?}")]
        [HttpGet]
        public async Task<ActionResult<UserAssignRoleVM>> ShowUserRole(string id)
        {
            var userAssignRole = await _userService.ShowUserRoleAsync(id);
            return userAssignRole;
        }

        [Route("[action]")]
        [HttpPost]
        public ActionResult<AuthResultApiModel> AssignRoles(UserAssignRoleVM role)
        {
            try
            {

                var authResult= _userService.AssignRole(role);
                return authResult;
               

            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }

        }

    }
}
