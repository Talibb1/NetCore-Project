


namespace Entities.ViewModel.Identity.UserVM
{
    public class UserAddVM
    {
        public string? Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;
        public string Status { get; set; } = null!;
    }
}
