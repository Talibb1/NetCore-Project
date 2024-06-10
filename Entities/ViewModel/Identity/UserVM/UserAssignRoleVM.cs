


using Microsoft.AspNetCore.Mvc.Rendering;

namespace Entities.ViewModel.Identity.UserVM
{
    public class UserAssignRoleVM
    {
        public UserListVM user { get; set; } = null!;

        public  List<SelectListItem> roles { get; set; } = null!;

    }
}
