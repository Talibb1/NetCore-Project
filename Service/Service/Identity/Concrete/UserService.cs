using AutoMapper;
using BaseLayer.Model;
using Entities.Entity.Identity;
using Entities.ViewModel.Identity.UserVM;
using Entities.ViewModel.PagerVM;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repository.DbContext;
using Service.Helper.Abstract;
using Service.Service.Identity.Abstract;


namespace Service.Service.Identity.Concrete
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        private readonly IPagerHelper _pagerHelper;

        private readonly IMapper _mapper;

        private readonly AppDbContext _context;
        public UserService(UserManager<AppUser> userManager, IMapper mapper, IPagerHelper pagerHelper, AppDbContext context, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _pagerHelper = pagerHelper;
            _context = context;
            _roleManager = roleManager;
        }

        public PagingVM GetUserAsync(int CurrentPagingCount)
        {
            PagingVM pager = new PagingVM();
            int PagingCount = 0;
            var appUser = _pagerHelper.PagingGenericRepositry<AppUser>().Paging(CurrentPagingCount, 5, ref PagingCount).ToList();

            var userListVM = _mapper.Map<List<UserListVM>>(appUser);
            pager.userListVM = userListVM;
            pager.Paging = new PagerModel();
            pager.Paging.CurrentPageCount = CurrentPagingCount == 0 ? 1 : CurrentPagingCount;
            pager.Paging.PagingCount = PagingCount;

            return pager;
        }

        public async Task<UserUpdateVM> GetUserByIdAsync(string userId)
        {
            var AppUser = await _userManager.FindByIdAsync(userId);
            var userUpdateVN = _mapper.Map<UserUpdateVM>(AppUser);

            return userUpdateVN;


        }

        public async Task<AuthResultApiModel> AddUserAsync(UserAddVM request)
        {
            var appUser = _mapper.Map<AppUser>(request);
          var result=  await _userManager.CreateAsync(appUser, request.PasswordHash);
            if (result.Succeeded)
            {
                return new AuthResultApiModel()
                {
                    Error = false,
                    Message = "User add successfully"
                };
            }
            return new AuthResultApiModel()
            {
                Error = true,
                Message = result.Errors.ToString()!
            };
        }

        public async Task<AuthResultApiModel> UpdateUserAsync(UserUpdateVM request)
        {
            var user = await _userManager.FindByIdAsync(request.Id);
            var appUser = _mapper.Map(request,user);
           
            await _userManager.UpdateAsync(appUser);
            return new AuthResultApiModel()
            {
                Error = false,
                Message = "User update successfully"
            };
        }


        // for user assign role

        public async Task<UserAssignRoleVM> ShowUserRoleAsync(string userId)
        {
            var assignRole = new UserAssignRoleVM();

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userId);

            var userListVM = _mapper.Map<UserListVM>(user);

            var userInRole = await _context.UserRoles.Where(x => x.UserId == userId).Select(x => x.RoleId).ToListAsync();

            assignRole.roles = await _roleManager.Roles.Select(x => new SelectListItem()
            {
                Value = x.Id,
                Text = x.Name,
                Selected = userInRole.Contains(x.Id)
            }).ToListAsync();
            assignRole.user = userListVM;

            return assignRole;
        }

        public AuthResultApiModel AssignRole(UserAssignRoleVM role)
        {
            var userAlreadyInRole = _context.UserRoles.Where(x => x.UserId == role.user.Id).Select(x => x.RoleId).ToList();
            var selectedRole = role.roles.Where(x => x.Selected).Select(x => x.Value).ToList();

            var toAdd = selectedRole.Except(userAlreadyInRole);
            var toRemove = userAlreadyInRole.Except(selectedRole);

            foreach (var item in toRemove)
            {
                _context.UserRoles.Remove(new AppUserRole()
                {
                    UserId = role.user.Id,
                    RoleId = item

                });
            }

            foreach (var item in toAdd)
            {
                _context.UserRoles.Add(new AppUserRole()
                {

                    UserId = role.user.Id,
                  RoleId = item,
                });
            }
            _context.SaveChanges();

            return new AuthResultApiModel()
            {
                Error = false,
                Message = "User assign role successfully"
            };
        }

    }
}
