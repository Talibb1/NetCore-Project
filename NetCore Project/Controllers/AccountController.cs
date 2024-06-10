using BaseLayer.Model;
using Entities.ViewModel.AccountVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Service.Helper.Abstract;
using Service.Service.Identity.Abstract;

namespace NetCore_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ISendEmailHelper _sendEmailHelper;

        public AccountController(IAccountService accountService, ISendEmailHelper sendEmailHelper)
        {
            _accountService = accountService;
            _sendEmailHelper = sendEmailHelper;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<AuthResultApiModel>> Login(LoginVM request)
        {

            var apiMessageModel = await _accountService.LoginAsync(request);
            return apiMessageModel;
        }


        [Route("[action]")]
        [HttpPost]
        public async Task<ActionResult<AuthResultApiModel>> Signup(SignUpVM request)
        {
            var authResult = await _accountService.Signup(request);
            return authResult;

        }


        [Route("[action]")]
        public async Task<ActionResult<AuthResultApiModel>> ForgetPassword(ForgetPasswordVM request)
        {
            var authResult = await _accountService.ForgetPasswordAsync(request);
            if (!authResult.Error)
            {
                var resetLink = Url.Action("ResetPassword", "Account", new { userId = authResult.Id, token = authResult.Token }, HttpContext.Request.Scheme);
                await _sendEmailHelper.SendEmail(resetLink!, request.Email);
                return new AuthResultApiModel()
                {
                    Error = false,
                    Message = "token send your email"
                };

            }
            return authResult;
        }


        [Route("[action]")]
        public async Task<ActionResult<AuthResultApiModel>> ResetPasswordAsync(ResetPasswordVM request, string userId, string token)
        {
            var authResult = await _accountService.ResetPasswordAsync(request,userId,token);
            return authResult;
        }


        [Route("[action]")]
        public async Task<ActionResult<AuthResultApiModel>> LogOutAsync()
        {
           var authResult= await  _accountService.LogOutAsync();
           return authResult;      
        }

    }
}
