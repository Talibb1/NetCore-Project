using AutoMapper;
using BaseLayer.Model;
using Entities.Entity.WebApplication;
using Entities.ViewModel.PagerVM;
using Entities.ViewModel.WebApplication.CategoryVM;
using Microsoft.EntityFrameworkCore;
using Repository.UnitOfWork.Abstract;
using Service.Helper.Abstract;
using Service.Service.WebApplication.Abstract;


namespace Service.Service.WebApplication.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;
        private readonly IPagerHelper _pagerHelper;
        public CategoryService(IUnitOfWork unit, IMapper mapper, IPagerHelper pagerHelper)
        {
            _unit = unit;
            _mapper = mapper;
            _pagerHelper = pagerHelper;
        }

        public async Task<AuthResultApiModel> AddEntityAsync(CategoryAddVM request)
        {
            var addCategory = _mapper.Map<Category>(request);
            await _unit.GetGenericRepository<Category>().AddAsync(addCategory);
            await _unit.CommitAsync();
            return new AuthResultApiModel()
            {
                Error = false,
                Message = "category add successfully"
            };
        }

        public async Task<AuthResultApiModel> UpdateEntity(CategoryUpdateVM request)
        {
            var Category = await _unit.GetGenericRepository<Category>().Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            request.RowVersion = Category.RowVersion;

            var updateCategory = _mapper.Map(request, Category);
            _unit.GetGenericRepository<Category>().Update(updateCategory!);
            await _unit.CommitAsync();
            return new AuthResultApiModel()
            {
                Error = false,
                Message = "category update successfully"
            };
        }


        public async Task<AuthResultApiModel> DeleteEntityAsync(int Id)
        {
            var Category = await _unit.GetGenericRepository<Category>().Where(x => x.Id == Id).FirstOrDefaultAsync();
            _unit.GetGenericRepository<Category>().Delete(Category!);
            await _unit.CommitAsync();
            return new AuthResultApiModel()
            {
                Error = false,
                Message = "category delete successfully"
            };
        }


        public async Task<CategoryListVM> GetEntityByIdAsync(int Id)
        {


            var Category = await _unit.GetGenericRepository<Category>().Where(x => x.Id == Id).FirstOrDefaultAsync();
            var CategoryList = _mapper.Map<CategoryListVM>(Category);
            return CategoryList;
        }


        public PagingVM GetEntityAsync(int CurrentPagingCount)
        {
            PagingVM pager = new PagingVM();
            int PagingCount = 0;
            var categories = _pagerHelper.PagingGenericRepositry<Category>().Paging(CurrentPagingCount, 5, ref PagingCount).ToList();

            var categoryListVM = _mapper.Map<List<CategoryListVM>>(categories);
            pager.categoryListVM = categoryListVM;
            pager.Paging = new PagerModel();
            pager.Paging.CurrentPageCount = CurrentPagingCount == 0 ? 1 : CurrentPagingCount;
            pager.Paging.PagingCount = PagingCount;

            return pager;

        }

    }
}
