

namespace Entities.ViewModel.Identity.UserVM
{
    public class UserListVM
    {
        public string Id { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Email { get; set; }=null!;

        public string PasswordHash { get; set; } = null!;


    }
}
