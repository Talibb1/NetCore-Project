using AutoMapper;
using BaseLayer.Model;
using Entities.Entity.WebApplication;
using Entities.ViewModel.PagerVM;
using Entities.ViewModel.WebApplication.CategoryVM;
using Microsoft.AspNetCore.Mvc;
using Service.Service.WebApplication.Abstract;

namespace NetCore_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }


        //get category list
        [Route("[action]/{CurrentPageCount?}")]
        [HttpGet]
        public ActionResult<PagingVM> GetList(int CurrentPageCount)
        {
            var pagerVM = _service.GetEntityAsync(CurrentPageCount);
            return Ok(pagerVM);
        }

        //get category by id
        [Route("[action]/{Id?}")]
        [HttpGet]
        public async Task<ActionResult<CategoryListVM>> GetById(int Id)
        {
            var Categories = await _service.GetEntityByIdAsync(Id);
            return Ok(Categories);
        }

        //add category
        [Route("[action]")]
        [HttpPost]
        public async Task<ActionResult<AuthResultApiModel>> Add(CategoryAddVM request)
        {
           var authResult= await _service.AddEntityAsync(request);
            return Ok(authResult);
        }

        //update category
        [Route("[action]/{Id?}")]
        [HttpPut]
        public async Task<ActionResult<AuthResultApiModel>> Update(CategoryUpdateVM request)
        {
            var authResult = await _service.GetEntityByIdAsync(request.Id);
            return Ok(authResult);  
        }


        //delete category
        [Route("[action]/{Id?}")]
        [HttpDelete]
        public async Task<ActionResult<AuthResultApiModel>> Delete(int Id)
        {
            var authResult = await _service.GetEntityByIdAsync(Id);
          return  Ok(authResult);
        }


    }
}
