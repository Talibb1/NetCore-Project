using Entities.Entity.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration.Identity
{
    public class UserRoleConfig : IEntityTypeConfiguration<AppUserRole>

    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {

            builder.HasData(new AppUserRole()
            {

                RoleId = Guid.Parse("E337E5B4-63EF-4617-8E43-18A90B97C451").ToString(),
                UserId = Guid.Parse("D1B066CB-5A51-4EB3-8AFE-BE2BF305648F").ToString(),
            }, new AppUserRole()
            {

                RoleId = Guid.Parse("5B2200A1-34FD-4FE0-A66F-F220F14AD3D2").ToString(),
                UserId = Guid.Parse("7DF0C8CD-26F4-488D-B76F-4B4AAC7D56A2").ToString(),
            },new AppUserRole()
            {
                RoleId = Guid.Parse("1E86C687-BB03-45F3-9B7E-3ADD5F6CC138").ToString(),
                UserId = Guid.Parse("2DB2186C-6E17-4BB0-8AE1-FAD543F3196C").ToString(),

            });
        }
    }
}
