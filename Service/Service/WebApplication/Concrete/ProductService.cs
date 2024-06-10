using AutoMapper;
using BaseLayer.Model;
using Entities.Entity.WebApplication;
using Entities.ViewModel.PagerVM;
using Entities.ViewModel.WebApplication.CategoryVM;
using Entities.ViewModel.WebApplication.ProductVM;
using Microsoft.EntityFrameworkCore;
using Repository.UnitOfWork.Abstract;
using Service.Helper.Abstract;
using Service.Service.WebApplication.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service.WebApplication.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;
        private readonly IPagerHelper _pagerHelper;
        public ProductService(IUnitOfWork unit, IMapper mapper, IPagerHelper pagerHelper)
        {
            _unit = unit;
            _mapper = mapper;
            _pagerHelper = pagerHelper;
        }

        public async Task AddEntityAsync(ProductAddVM request)
        {
            var addProduct = _mapper.Map<Product>(request);
            await _unit.GetGenericRepository<Product>().AddAsync(addProduct);
            await _unit.CommitAsync();
        }

        public async Task UpdateEntity(ProductUpdateVM request)
        {
            var product = await _unit.GetGenericRepository<Product>().Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            request.RowVersion = product!.RowVersion;

            var updateProduct = _mapper.Map(request, product);
            _unit.GetGenericRepository<Product>().Update(updateProduct!);
            await _unit.CommitAsync();
        }


        public async Task DeleteEntityAsync(int Id)
        {
            var Product = await _unit.GetGenericRepository<Product>().Where(x => x.Id == Id).FirstOrDefaultAsync();
            _unit.GetGenericRepository<Product>().Delete(Product!);
            await _unit.CommitAsync();
        }


        public async Task<ProductListVM> GetEntityByIdAsync(int Id)
        {


            var Product = await _unit.GetGenericRepository<Product>().Where(x => x.Id == Id).FirstOrDefaultAsync();
            var ProductList = _mapper.Map<ProductListVM>(Product);
            return ProductList;
        }


        public PagingVM GetEntityAsync(int CurrentPagingCount)
        {
            PagingVM pager = new PagingVM();
            int PagingCount = 0;
            var Products = _pagerHelper.PagingGenericRepositry<Product>().Paging(CurrentPagingCount, 5, ref PagingCount);

            var productListVM = _mapper.Map<List<ProductListVM>>(Products);
            pager.productListVM = productListVM;
            pager.Paging = new PagerModel();
            pager.Paging.CurrentPageCount = CurrentPagingCount == 0 ? 1 : CurrentPagingCount;
            pager.Paging.PagingCount = PagingCount;

            return pager;

        }

    }
}
