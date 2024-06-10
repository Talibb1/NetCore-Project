
using AutoMapper;
using BaseLayer.Model;
using Entities.ViewModel.PagerVM;
using Entities.ViewModel.WebApplication.CategoryVM;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Service.ConsumeService.WebApplication.Abstract;

namespace Tracker.Areas.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryConsumeService _consumeService;

        private readonly IValidator<CategoryAddVM> _addValidation;
        private readonly IValidator<CategoryUpdateVM> _updateValidation;

        
        private readonly IMapper _mapper;

        public CategoryController(ICategoryConsumeService consumeService, IValidator<CategoryAddVM> addValidation, IValidator<CategoryUpdateVM> updateValidation, IMapper mapper)
        {
            _consumeService = consumeService;
            _addValidation = addValidation;
            _updateValidation = updateValidation;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("[action]")]
        public IActionResult Index(int CurrentPageCount)
        {
             var consumePagingVM = new PagingVM();
             consumePagingVM.Paging = new PagerModel();
            consumePagingVM = _consumeService.GetCategories(CurrentPageCount);
            

            //for pagination HTTP and Ajax Request
            var pager = new PagingVM();
            pager.Paging = new PagerModel();


            pager.Paging!.CurrentPageCount= consumePagingVM.Paging!.CurrentPageCount;
            pager.Paging.PagingCount= consumePagingVM.Paging!.PagingCount;
            pager.Categories = consumePagingVM.Categories;

            return View(pager);
        }


        [HttpGet]
        [Route("[action]/{Id?}")]
        public  IActionResult Details(int Id)
        {
            var categoryListVM = _consumeService.GetCategoriesById(Id);
            var categoryUpdateVM = _mapper.Map<CategoryUpdateVM>(categoryListVM);
           
            return View(categoryUpdateVM);
        }


        
        [HttpGet]
        [Route("[action]")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        [Route("[action]/{id?}")]
        public IActionResult Deletes(int id)
        {
            var categoryListVM = _consumeService.GetCategoriesById(id);
            var categoryUpdateVM = _mapper.Map<CategoryUpdateVM>(categoryListVM);

            return View(categoryUpdateVM);
        }




        //for all HTTPOST method
        [HttpPost]
        public async Task<IActionResult> Update(CategoryUpdateVM request)
        {

            var result = await _updateValidation.ValidateAsync(request);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                return View("Details", request);
            }

            //service here
            _consumeService.UpdateCategoryAsync(request);    
            return RedirectToAction("Index", "Category", new { Areas = "Admin" });
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
             //service here
              _consumeService.DeleteCategoryAsync(id);
                
            return RedirectToAction("Index", "Category", new { Areas = "Admin" });
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryAddVM request)
        {
            var result = await _addValidation.ValidateAsync(request);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                return View(request);
            }

            //service here
            _consumeService.CreateCategoryAsync(request);
            return RedirectToAction("Index", "Category", new { Areas = "Admin" });
          
        }


      
    }
}
