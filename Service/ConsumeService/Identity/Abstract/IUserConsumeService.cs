using Entities.ViewModel.Identity.UserVM;
using Entities.ViewModel.PagerVM;


namespace Service.ConsumeService.Identity.Abstract
{
    public interface IUserConsumeService
    {
        bool AddUser(UserAddVM request);
        bool AssignRoles(UserAssignRoleVM role);
        PagingVM GetUser(int CurrentPagerCount);
        UserUpdateVM GetUserById(string userId);
        UserAssignRoleVM ShowUserRole(string userId);
        bool UpdateUser(UserUpdateVM request);
    }
}