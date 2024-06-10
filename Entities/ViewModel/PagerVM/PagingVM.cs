using BaseLayer.Model;
using Entities.ViewModel.Identity.RoleVM;
using Entities.ViewModel.Identity.UserVM;
using Entities.ViewModel.WebApplication.CategoryVM;
using Entities.ViewModel.WebApplication.ProductVM;



namespace Entities.ViewModel.PagerVM
{
    public class PagingVM
    {

        public List<CategoryListVM>? Categories { get; set; }


        public List<RoleListVM>? roles { get; set; }

        public List<UserListVM>? userListVM { get; set; }

        public List<CategoryListVM>? categoryListVM { get; set; }

        public List<ProductListVM>? productListVM { get; set; }
        public PagerModel? Paging { get; set; }
    }
}
