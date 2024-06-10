using AutoMapper;
using BaseLayer.Model;
using Entities.Entity.Identity;
using Entities.ViewModel.AccountVM;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Service.ConsumeService.Identity.Abstract;
using Service.Helper.Abstract;

namespace UserPanelNetCore.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountConsumeService _accountConsumeService;


        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        private readonly IValidator<LoginVM> _loginValidation;
        private readonly IValidator<SignUpVM> _signupValidation;

        private readonly ISendEmailHelper _sendEmailHelper;

        private readonly IMapper _mapper;

        public AccountController(IAccountConsumeService accountConsumeService, IValidator<LoginVM> loginValidation, IValidator<SignUpVM> signupValidation, ISendEmailHelper sendEmailHelper, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IMapper mapper)
        {
            _accountConsumeService = accountConsumeService;
            _loginValidation = loginValidation;
            _signupValidation = signupValidation;
            _sendEmailHelper = sendEmailHelper;
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Signup()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginVM request, string? returnUrl)
        {
            var result = await _loginValidation.ValidateAsync(request);
            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
                return View(request);
            }
           returnUrl = returnUrl == null ? "/Home/Index" : returnUrl;


            var appUser = await _userManager.FindByEmailAsync(request.Email);

            if (appUser == null)
            {
                ViewData["error"] = "something error is occur";
                ModelState.AddModelError("", "invalid cradiential");
                return View("Login", request);
            }

            var results = await _signInManager.PasswordSignInAsync(appUser, request.PasswordHash, request.RememberMe, true);
            if (results.Succeeded)
            {

                return LocalRedirect(returnUrl);
            }

            var isLockOut = await _userManager.IsLockedOutAsync(appUser);
            if (isLockOut)
            {
                ViewData["error"] = "something error is occur";
                ModelState.AddModelError("", "your  account is lockout for 5 second");
                return View("Login", request);

            }
            ViewData["error"] = "something error is occur";
            ModelState.AddModelError("", $"invalid Password attempt {await _userManager.GetAccessFailedCountAsync(appUser)} out of 5");
            return View("Login", request);


        }



        [HttpPost]
        public async Task<IActionResult> SignupAsync(SignUpVM request)
        {
            var result = await _signupValidation.ValidateAsync(request);
            if (!result.IsValid)
            {
              
                result.AddToModelState(ModelState);
                return View(request);
            }

            request.Id = Guid.NewGuid().ToString();
            request.Status = "False";
            var appUser = _mapper.Map<AppUser>(request);

            var results = await _userManager.CreateAsync(appUser, request.PasswordHash);
            if (results.Succeeded)
            {
                // assign by default user role
                var user = await _userManager.FindByIdAsync(request.Id);
                await _userManager.AddToRoleAsync(user, "User");

                var token = await _userManager.GenerateChangeEmailTokenAsync(user, user.Email);
                var resetLink = Url.Action("Login", "Account", new { token = token }, HttpContext.Request.Scheme);
                await _sendEmailHelper.SendEmail(resetLink!, request.Email);
                ViewData["error"] = "token send your email";
                ModelState.AddModelError("", "token send your email");
                return View("Signup", request);

            }


            //var checkUser = _accountConsumeService.Signup(request);
            //if (checkUser.Error)
            //{
            //    ViewData["error"] = checkUser.Message;
            //    ModelState.AddModelError("", checkUser.Message!);
            //    return View(request);
            //}


            //ViewData["error"] = checkUser.Error;
            //ModelState.AddModelError("", checkUser.Error.ToString()!);
            //return View("Signup", request);

            ViewData["error"] = results.Errors;
            ModelState.AddModelError("", results.Errors.ToString()!);
            return View("Signup",request);


        }


        public IActionResult AccessDenied()
        {
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new {Areas=""});
        }

    }
}
