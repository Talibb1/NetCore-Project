using Entities.ViewModel.Identity.UserVM;
using FluentValidation;
using ServiceEntityLayer.Message;


namespace Service.FluentValidation.Identity.UserValidation
{
    public class UserAddValidation : AbstractValidator<UserAddVM>
    {
        public UserAddValidation()
        {
            RuleFor(x => x.UserName).NotEmpty().NotNull().WithMessage(FluentMessage.NullEmptyMessage("Name"));
            RuleFor(x => x.PasswordHash).NotEmpty().NotNull().WithMessage(FluentMessage.NullEmptyMessage("Name"));
            RuleFor(x => x.Status).NotEmpty().NotNull().WithMessage(FluentMessage.NullEmptyMessage("Name"));
            
            RuleFor(x => x.Email).NotEmpty().NotNull().WithMessage(FluentMessage.NullEmptyMessage("Name"));
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email is not correct format");

        }
    }
}
