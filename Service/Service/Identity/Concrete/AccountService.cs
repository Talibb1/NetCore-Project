
using AutoMapper;
using BaseLayer.Model;
using Entities.Entity.Identity;
using Entities.ViewModel.AccountVM;
using Microsoft.AspNetCore.Identity;
using Repository.DbContext;
using Service.Service.Identity.Abstract;


namespace Service.Service.Identity.Concrete
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        private readonly IMapper _mapper;



        private readonly AppDbContext _context;
        public AccountService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _context = context;
        }

        public async Task<AuthResultApiModel> LoginAsync(LoginVM request)
        {

            var appUser = await _userManager.FindByEmailAsync(request.Email);

            if (appUser == null)
            {
                return new AuthResultApiModel()
                {
                    Error = true,
                    Message = "invalid Credential"
                };
            }

            var result = await _signInManager.PasswordSignInAsync(appUser, request.PasswordHash, request.RememberMe, true);
            if (result.Succeeded)
            {

                return new AuthResultApiModel()
                {
                    Error = false,
                    Message = "Login Successed"
                };


            }

            var isLockOut = await _userManager.IsLockedOutAsync(appUser);
            if (isLockOut)
            {
                return (new AuthResultApiModel()
                {
                    Error = true,
                    Message = "your  account is lockout for 5 second"
                });

            }

            return (new AuthResultApiModel()
            {
                Error = true,
                Message = $"invalid <b>Password</b> attempt {await _userManager.GetAccessFailedCountAsync(appUser)} out of 5"
            });

        }


        public async Task<AuthResultApiModel> Signup(SignUpVM request)
        {

            var appUser = _mapper.Map<AppUser>(request);

            var result = await _userManager.CreateAsync(appUser, request.PasswordHash);
            if (result.Succeeded)
            {
                // assign by default user role
                var user = await _userManager.FindByIdAsync(request.Id);
                await _userManager.AddToRoleAsync(user, "User");

                var token = await _userManager.GenerateChangeEmailTokenAsync(user, user.Email);

                return new AuthResultApiModel()
                {
                    Error = false,
                    Token = token,
                    Message = "token is send to email"
                };
            }

            return new AuthResultApiModel()
            {
                Error = true,
                Message = result.Errors.ToString()!
            };
        }


        public async Task<AuthResultApiModel> ForgetPasswordAsync(ForgetPasswordVM request)
        {
            var checkUser = await _userManager.FindByEmailAsync(request.Email);
            if (checkUser == null)
            {
                return new AuthResultApiModel()
                {
                    Message = "Invalid Email! please register yourself",
                    Error = true
                };


            }
            var token = await _userManager.GeneratePasswordResetTokenAsync(checkUser);
             return new AuthResultApiModel
            {
                 Message="token send your email",
                Error = false,
                Token = token,
                Email = request.Email,
                Id = checkUser.Id
                 

            };

        }

        public async Task<AuthResultApiModel> ResetPasswordAsync(ResetPasswordVM request, string userId, string token)
        {

            var appUser = await _userManager.FindByIdAsync(userId);
            if (appUser == null)
            {
                return new AuthResultApiModel()
                {
                    Error = true,
                    Message = "Invalid credential! please Register yourself",

                };
            }


            var isPasswordReset = await _userManager.ResetPasswordAsync(appUser, token, request.NewPassword);
            if (!isPasswordReset.Succeeded)
            {
                return new AuthResultApiModel()
                {
                    Error = true,
                    Message = "Something went wrong please try again"
                };

            }
            return new AuthResultApiModel()
            {
                Error = false,
                Message = "Your password is successfully changed"
            };

        }


        public async Task<AuthResultApiModel> LogOutAsync()
        {
            await _signInManager.SignOutAsync();
            return new AuthResultApiModel()
            {
                Error = false,
                Message = "your are successfully logout"
            };
        }



    }
}
