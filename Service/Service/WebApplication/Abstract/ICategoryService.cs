using BaseLayer.Model;
using Entities.ViewModel.PagerVM;
using Entities.ViewModel.WebApplication.CategoryVM;

namespace Service.Service.WebApplication.Abstract
{
    public interface ICategoryService
    {
        Task<AuthResultApiModel> AddEntityAsync(CategoryAddVM request);
        Task<AuthResultApiModel> DeleteEntityAsync(int Id);
        PagingVM GetEntityAsync(int CurrentPagingCount);
        Task<CategoryListVM> GetEntityByIdAsync(int Id);
        Task<AuthResultApiModel> UpdateEntity(CategoryUpdateVM request);
    }
}