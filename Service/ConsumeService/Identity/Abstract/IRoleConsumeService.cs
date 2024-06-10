
using Entities.ViewModel.Identity.RoleVM;

namespace Service.ConsumeService.Identity.Abstract
{
    public interface IRoleConsumeService
    {
        bool Create(RoleAddVM request);
        bool Delete(string Id);
        List<RoleListVM> GetRole();
        RoleListVM GetRoleById(string Id);
        bool Update(RoleUpdateVM request);
    }
}