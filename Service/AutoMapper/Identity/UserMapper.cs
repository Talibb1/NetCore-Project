using AutoMapper;
using Entities.Entity.Identity;
using Entities.ViewModel.Identity.UserVM;



namespace ServiceEntityLayer.AutoMapper.Identity
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<UserListVM, AppUser>().ReverseMap();
            CreateMap<UserAddVM, AppUser>().ReverseMap();
            CreateMap<UserUpdateVM, AppUser>().ReverseMap();
            CreateMap<UserUpdateVM, UserListVM>().ReverseMap();





        }
    }
}
