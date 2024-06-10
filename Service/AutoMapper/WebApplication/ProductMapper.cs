using AutoMapper;
using Entities.Entity.WebApplication;
using Entities.ViewModel.WebApplication.ProductVM;


namespace Service.AutoMapper.WebApplication
{
    public class ProductMapper:Profile
    {
         public ProductMapper() 
        {
            CreateMap<ProductAddVM, Product>().ReverseMap();
            CreateMap<ProductListVM, Product>().ReverseMap();
            CreateMap<ProductUpdateVM, Product>().ReverseMap();


        }
    }
}
