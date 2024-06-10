using Entities.Entity.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Repository.Configuration.Identity
{
    public class UserConfig : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            var user = new AppUser()
            {
                Id = Guid.Parse("7DF0C8CD-26F4-488D-B76F-4B4AAC7D56A2").ToString(),
                ConcurrencyStamp = Guid.Parse("73570BBD-31A2-438C-85AF-28F050AEC241").ToString(),
                SecurityStamp = Guid.Parse("294196C6-9D39-44C5-8CB0-35BFAE31AAD1").ToString(),
                Email = "user@gmail.com",
                NormalizedEmail = "user@gmail.com".ToUpper(),
                UserName = "user",
                NormalizedUserName = "user".ToUpper(),

            };

            var admin = new AppUser()
            {
                Id = Guid.Parse("D1B066CB-5A51-4EB3-8AFE-BE2BF305648F").ToString(),
                ConcurrencyStamp = Guid.Parse("2247B106-D8DB-44ED-A1F0-9390F7A052E2").ToString(),
                SecurityStamp = Guid.Parse("76FD4E36-7941-4ACF-B435-9890A776DE0C").ToString(),
                Email = "admin@gmail.com",
                NormalizedEmail = "admin@gmail.com".ToUpper(),
                UserName = "admin",
                NormalizedUserName = "admin".ToUpper(),

            };
            
            var superAdmin = new AppUser()
            {
                Id = Guid.Parse("2DB2186C-6E17-4BB0-8AE1-FAD543F3196C").ToString(),
                ConcurrencyStamp = Guid.Parse("2838DCB7-8F70-45C4-8B23-55AA586B7FA1").ToString(),
                SecurityStamp = Guid.Parse("F55DE288-0EF2-4709-8BB9-373D9B040490").ToString(),
                Email = "superAdmin@gmail.com",
                NormalizedEmail = "superAdmin@gmail.com".ToUpper(),
                UserName = "superAdmin",
                NormalizedUserName = "superAdmin".ToUpper(),

            };

            var userPasswordHash = generatePasswordHash(user, "user@123");
            user.PasswordHash = userPasswordHash;

            var adminPasswordHash = generatePasswordHash(admin, "admin@123");
            admin.PasswordHash = adminPasswordHash;
           
            var superAdminPasswordHash = generatePasswordHash(superAdmin, "superAdmin@123");
            superAdmin.PasswordHash = superAdminPasswordHash;


            builder.HasData(user,admin,superAdmin);

           

        }

        public static string generatePasswordHash(AppUser user,string password)
        {
            var generatePassword=new PasswordHasher<AppUser>();
           return generatePassword.HashPassword(user, password);
        }
    }
}
