using AutoMapper;
using BaseLayer.Model;
using Entities.ViewModel.Identity.RoleVM;
using Microsoft.AspNetCore.Mvc;
using Service.Service.Identity.Abstract;

namespace NetCore_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        private readonly IMapper _mapper;

        public RoleController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<ActionResult<List<RoleListVM>>> GetRole()
        {
            var roleList = await _roleService.GetEntityAsync();
            return Ok(roleList);
        }

        [Route("[action]/{Id?}")]
        [HttpGet]
        public async Task<ActionResult<RoleListVM>> GetById(string Id)
        {
            var role = await _roleService.GetEntityByIdAsync(Id);
            return Ok(role);


        }


        [Route("[action]")]
        [HttpPost]
        public async Task<ActionResult<AuthResultApiModel>> Create(RoleAddVM request)
        {
           var authResult= await _roleService.AddEntityAsync(request);

            return Ok(authResult);
        }


        [Route("[action]")]
        [HttpPut]
        public async Task<ActionResult<AuthResultApiModel>> Update(RoleUpdateVM request)
        {
            var authResult = await _roleService.UpdateEntityAsync(request);
            return Ok(authResult);
        }

        [Route("[action]/{Id?}")]
        [HttpDelete]
        public async Task<ActionResult<AuthResultApiModel>> Delete(string Id)
        {

            var authResult = await _roleService.DeleteEntityAsync(Id);
            return Ok(authResult);
        }


    }
}
