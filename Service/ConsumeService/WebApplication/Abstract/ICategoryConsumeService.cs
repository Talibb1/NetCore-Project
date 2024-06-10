using BaseLayer.Model;
using Entities.ViewModel.PagerVM;
using Entities.ViewModel.WebApplication.CategoryVM;

namespace Service.ConsumeService.WebApplication.Abstract
{
    public interface ICategoryConsumeService
    {
        AuthResultApiModel CreateCategoryAsync(CategoryAddVM request);
        AuthResultApiModel DeleteCategoryAsync(int Id);
        PagingVM GetCategories(int CurrentPageCount);
        CategoryListVM GetCategoriesById(int Id);
        AuthResultApiModel UpdateCategoryAsync(CategoryUpdateVM request);
    }
}