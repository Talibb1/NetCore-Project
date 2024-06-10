using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModel.AccountVM
{
    public class SignUpVM
    {
        public string Id { get; set; } = null!;
        public string Email { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public string? Status { get; set; }
    }
}
