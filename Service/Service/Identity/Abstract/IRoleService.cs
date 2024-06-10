using BaseLayer.Model;
using Entities.ViewModel.Identity.RoleVM;

namespace Service.Service.Identity.Abstract
{
    public interface IRoleService
    {
        Task<AuthResultApiModel> AddEntityAsync(RoleAddVM request);
        Task<AuthResultApiModel> DeleteEntityAsync(string Id);
        Task<List<RoleListVM>> GetEntityAsync();
        Task<RoleListVM> GetEntityByIdAsync(string Id);
        Task<AuthResultApiModel> UpdateEntityAsync(RoleUpdateVM request);
    }
}