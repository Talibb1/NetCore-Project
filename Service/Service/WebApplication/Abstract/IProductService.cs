using Entities.ViewModel.PagerVM;
using Entities.ViewModel.WebApplication.ProductVM;

namespace Service.Service.WebApplication.Abstract
{
    public interface IProductService
    {
        Task AddEntityAsync(ProductAddVM request);
        Task DeleteEntityAsync(int Id);
        PagingVM GetEntityAsync(int CurrentPagingCount);
        Task<ProductListVM> GetEntityByIdAsync(int Id);
        Task UpdateEntity(ProductUpdateVM request);
    }
}