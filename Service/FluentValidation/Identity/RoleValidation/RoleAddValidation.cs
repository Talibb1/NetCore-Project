
using Entities.ViewModel.Identity.RoleVM;
using FluentValidation;
using ServiceEntityLayer.Message;



namespace ServiceEntityLayer.FluentValidation.Identity.RoleValidation
{
    public class RoleAddValidation : AbstractValidator<RoleAddVM>
    {
        public RoleAddValidation()
        {
          
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage(FluentMessage.NullEmptyMessage("Name"));
        }
    }
}
