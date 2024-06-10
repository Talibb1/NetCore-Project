using AutoMapper;
using Entities.Entity.Identity;
using Entities.ViewModel.AccountVM;


namespace Service.AutoMapper.Identity
{
    public class AccountMapper : Profile
    {
        public AccountMapper()
        {
            CreateMap<SignUpVM, AppUser>().ReverseMap();
        }
    }
}
