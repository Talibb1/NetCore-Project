using Entities.Entity.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Repository.Configuration.Identity
{
    public class RoleConfig : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.HasData(new AppRole()
            {
                Id = Guid.Parse("E337E5B4-63EF-4617-8E43-18A90B97C451").ToString(),
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
            }, new AppRole()
            {
                Id = Guid.Parse("5B2200A1-34FD-4FE0-A66F-F220F14AD3D2").ToString(),
                Name = "User",
                NormalizedName = "User",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
            },new AppRole()
            {
                Id = Guid.Parse("1E86C687-BB03-45F3-9B7E-3ADD5F6CC138").ToString(),
                Name = "SuperAdmin",
                NormalizedName = "SuperAdmin".ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),

            });
        }
    }
}
