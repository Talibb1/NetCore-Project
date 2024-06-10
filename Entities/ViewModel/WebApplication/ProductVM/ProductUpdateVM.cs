

using BaseLayer.BaseEntity;

namespace Entities.ViewModel.WebApplication.ProductVM
{
    public class ProductUpdateVM: BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;


    }
}
