using BaseLayer.Model;
using Entities.ViewModel.AccountVM;

namespace Service.Service.Identity.Abstract
{
    public interface IAccountService
    {
        Task<AuthResultApiModel> ForgetPasswordAsync(ForgetPasswordVM request);
        Task<AuthResultApiModel> LoginAsync(LoginVM request);
        Task<AuthResultApiModel> LogOutAsync();
        Task<AuthResultApiModel> ResetPasswordAsync(ResetPasswordVM request, string userId, string token);
        Task<AuthResultApiModel> Signup(SignUpVM request);
    }
}