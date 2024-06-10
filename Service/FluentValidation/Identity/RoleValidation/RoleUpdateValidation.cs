using Entities.ViewModel.Identity.RoleVM;
using FluentValidation;
using ServiceEntityLayer.Message;

namespace ServiceEntityLayer.FluentValidation.Identity.RoleValidation
{
    public class RoleUpdateValidation : AbstractValidator<RoleUpdateVM>
    {
        public RoleUpdateValidation()
        {

            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage(FluentMessage.NullEmptyMessage("Name"));
        }
    }
}
