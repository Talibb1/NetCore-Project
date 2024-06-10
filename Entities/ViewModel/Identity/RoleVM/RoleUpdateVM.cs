

namespace Entities.ViewModel.Identity.RoleVM
{
    public class RoleUpdateVM
    {
        public string? Id { get; set; }
        public string Name { get; set; }=null!;
        public byte[] RowVersion { get; set; } = null!; 
    }
}
