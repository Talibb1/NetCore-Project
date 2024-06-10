using AutoMapper;
using Entities.Entity.Identity;
using Entities.ViewModel.Identity.RoleVM;




namespace Service.AutoMapper.Identity
{
    public class RoleMapper : Profile
    {
        public RoleMapper()
        {
            CreateMap<RoleAddVM, AppRole>().ReverseMap();
            CreateMap<RoleUpdateVM, AppRole>().ReverseMap();
            CreateMap<RoleListVM, AppRole>().ReverseMap();
            CreateMap<RoleListVM, RoleUpdateVM>().ReverseMap();


        }
    }
}
