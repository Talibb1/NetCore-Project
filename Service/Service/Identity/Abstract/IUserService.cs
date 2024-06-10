using BaseLayer.Model;
using Entities.ViewModel.Identity.UserVM;
using Entities.ViewModel.PagerVM;

namespace Service.Service.Identity.Abstract
{
    public interface IUserService
    {
        Task<AuthResultApiModel> AddUserAsync(UserAddVM request);
        AuthResultApiModel AssignRole(UserAssignRoleVM role);
        PagingVM GetUserAsync(int CurrentPagingCount);
        Task<UserUpdateVM> GetUserByIdAsync(string userId);
        Task<UserAssignRoleVM> ShowUserRoleAsync(string userId);
        Task<AuthResultApiModel> UpdateUserAsync(UserUpdateVM request);
    }
}