
using Entities.ViewModel.WebApplication.CategoryVM;
using FluentValidation;
using ServiceEntityLayer.Message;

namespace ServiceEntityLayer.FluentValidation.WebApplication.CategoryValidation
{
    public class CategoryUpdateValidation : AbstractValidator<CategoryUpdateVM>
    {
        public CategoryUpdateValidation()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage(FluentMessage.NullEmptyMessage("Name"));
        }
    }
}
