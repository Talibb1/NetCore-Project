

namespace Entities.ViewModel.Identity.UserVM
{
    public class UserUpdateVM
    {
        public string? Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;
        public string Status { get; set; } = null!;

        public byte[] RowVersion { get; set; } = null!;
    }
}
