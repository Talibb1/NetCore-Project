using Entities.ViewModel.AccountVM;
using FluentValidation;
using ServiceEntityLayer.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.FluentValidation.Identity.AccountValidation
{
    public class ResetPasswordValidation : AbstractValidator<ResetPasswordVM>
    {
        public ResetPasswordValidation()
        {
            RuleFor(x => x.OldPassword).NotNull().NotEmpty().WithMessage(FluentMessage.NullEmptyMessage("OldPassword"));
            RuleFor(x => x.NewPassword).NotNull().NotEmpty().WithMessage(FluentMessage.NullEmptyMessage("NewPassword"));


        }
    }
}
