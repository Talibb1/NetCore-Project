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
    public class ForgetPasswordValidation : AbstractValidator<ForgetPasswordVM>
    {
        public ForgetPasswordValidation()
        {
            RuleFor(x => x.Email).NotNull().NotEmpty().WithMessage(FluentMessage.NullEmptyMessage("OldPassword"));
            
        }
    }
}
