using AutoMapper;
using BaseLayer.Model;
using Entities.Entity.Identity;
using Entities.ViewModel.Identity.RoleVM;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Service.Service.Identity.Abstract;


namespace Service.Service.Identity.Concrete
{
    public class RoleService : IRoleService
    {
        private readonly IMapper _mapper;

        private readonly RoleManager<AppRole> _roleManager;

        public RoleService(IMapper mapper, RoleManager<AppRole> roleManager)
        {
            _mapper = mapper;
            _roleManager = roleManager;
        }

        public async Task<AuthResultApiModel> AddEntityAsync(RoleAddVM request)
        {
            var appRole = _mapper.Map<AppRole>(request);
            await _roleManager.CreateAsync(appRole);
            return new AuthResultApiModel()
            {
                Error = false,
                Message = "role add successfully"
            };

        }

        public async Task<AuthResultApiModel> UpdateEntityAsync(RoleUpdateVM request)
        {
            var role = await _roleManager.FindByIdAsync(request.Id);
            var appRole = _mapper.Map(request, role);
            await _roleManager.UpdateAsync(appRole);

            return new AuthResultApiModel()
            {
                Error = false,
                Message = "role update successfully"
            };

        }
        public async Task<AuthResultApiModel> DeleteEntityAsync(string Id)
        {
            var appRole = await _roleManager.FindByIdAsync(Id);
            await _roleManager.DeleteAsync(appRole);

            return new AuthResultApiModel()
            {
                Error = false,
                Message = "role delete successfully"
            };

        }

        public async Task<RoleListVM> GetEntityByIdAsync(string Id)
        {
            var appRole = await _roleManager.FindByIdAsync(Id);
            var roleList = _mapper.Map<RoleListVM>(appRole);
            return roleList;
        }


        public async Task<List<RoleListVM>> GetEntityAsync()
        {
            var appRole = await _roleManager.Roles.ToListAsync();
            var roleList = _mapper.Map<List<RoleListVM>>(appRole);
            return roleList;
        }


    }
}
