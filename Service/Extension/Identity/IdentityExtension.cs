using BaseLayer.Model;
using Entities.Entity.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.DbContext;


namespace Service.Extension.Identity
{
    public static class IdentityExtension
    {
        public static  IServiceCollection LoadIdentity(this IServiceCollection service,IConfiguration config)
        {

            // add identity
            service.AddIdentity<AppUser, AppRole>(op =>
            {
                op.Password.RequireNonAlphanumeric = false;
                op.Password.RequiredLength = 3;
                op.Password.RequireUppercase = false;   
                op.Password.RequireLowercase = false;
                op.Password.RequireDigit = false;

                op.User.AllowedUserNameCharacters = "";
                
                op.Lockout.DefaultLockoutTimeSpan=TimeSpan.FromMinutes(1);
                op.Lockout.MaxFailedAccessAttempts = 5;

            }).AddRoleManager<RoleManager<AppRole>>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            // add cookie
            service.ConfigureApplicationCookie(op =>
            {
                var cookie = new CookieBuilder();
                cookie.Name = "NetCore";

                op.AccessDeniedPath = new PathString("/Account/AccessDenied");
                op.LoginPath = new PathString("/Account/Login");
                op.LogoutPath = new PathString("/Account/Logout");
                op.Cookie = cookie;


            });

            // add  TokenLifeSpan
            service.Configure<DataProtectionTokenProviderOptions>(op =>
            {
                op.TokenLifespan = TimeSpan.FromMinutes(60);

            });
            service.Configure<GmailInfoModel>(config.GetSection("GmailSetting"));
            return service;
        }
    }
}
