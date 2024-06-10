using Entities.ViewModel.WebApplication.ProductVM;
using FluentValidation;
using ServiceEntityLayer.Message;

namespace Service.FluentValidation.WebApplication.ProductValidation
{
    public class ProductAddValidation : AbstractValidator<ProductAddVM>
    {
        public ProductAddValidation()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage(FluentMessage.NullEmptyMessage("Name"));
            RuleFor(x => x.Description).NotEmpty().NotNull().WithMessage(FluentMessage.NullEmptyMessage("Description"));
        }
    }
}
