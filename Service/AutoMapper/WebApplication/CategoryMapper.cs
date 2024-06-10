using AutoMapper;
using Entities.Entity.WebApplication;
using Entities.ViewModel.WebApplication.CategoryVM;

namespace Service.AutoMapper.WebApplication
{
    public class CategoryMapper:Profile
    {
        public CategoryMapper() 
        {
            CreateMap<CategoryAddVM, Category>().ReverseMap();
            CreateMap<CategoryListVM, Category>().ReverseMap();
            CreateMap<CategoryUpdateVM, Category>().ReverseMap();


        }
    }
}
