﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModel.AccountVM
{
    public class ResetPasswordVM
    {
        public string NewPassword { get; set; } = null!;

        public string OldPassword { get; set; } = null!;
    }
}
