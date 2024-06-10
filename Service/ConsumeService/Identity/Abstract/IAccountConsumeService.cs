using BaseLayer.Model;
using Entities.ViewModel.AccountVM;

namespace Service.ConsumeService.Identity.Abstract
{
    public interface IAccountConsumeService
    {
        AuthResultApiModel ForgetPassword(ForgetPasswordVM request);
        AuthResultApiModel Login(LoginVM request);
        AuthResultApiModel LogOutAsync(ResetPasswordVM request);
        AuthResultApiModel ResetPasswordAsync(ResetPasswordVM request);
        AuthResultApiModel Signup(SignUpVM request);
    }
}