
using Entities.ViewModel.AccountVM;
using FluentValidation;
using ServiceEntityLayer.Message;


namespace ServiceEntityLayer.FluentValidation.Identity.AccountValidation
{
    public class LoginValidation : AbstractValidator<LoginVM>
    {
        public LoginValidation()
        {
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email is not correct format");
            RuleFor(x => x.Email).NotEmpty().NotNull().WithMessage(FluentMessage.NullEmptyMessage("Email"));
            RuleFor(x => x.PasswordHash).NotEmpty().NotNull().WithMessage(FluentMessage.NullEmptyMessage("Password"));
        }
    }
}
