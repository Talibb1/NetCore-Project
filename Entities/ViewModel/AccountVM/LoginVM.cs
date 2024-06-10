

namespace Entities.ViewModel.AccountVM
{
    public class LoginVM
    {
        public string Email { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        public bool RememberMe { get; set; }
    }
}
