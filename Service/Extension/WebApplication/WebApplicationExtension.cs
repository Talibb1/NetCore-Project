using Microsoft.Extensions.DependencyInjection;
using Service.ConsumeService.Identity.Abstract;
using Service.ConsumeService.Identity.Concrete;
using Service.ConsumeService.WebApplication.Abstract;
using Service.ConsumeService.WebApplication.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Service.Extension.WebApplication
{
    public static class WebApplicationExtension
    {
        public static IServiceCollection LoadWebApplication(this IServiceCollection service)
        {
            //Inject Service
            var services=Assembly.GetExecutingAssembly().GetTypes().Where(x => x.IsClass && x.Name.EndsWith("Service") && !x.IsAbstract).ToList();
            foreach(var item in services)
            {
                var IService = item.GetInterfaces().FirstOrDefault(x => x.Name == $"I{item.Name}");
                if (IService != null) service.AddScoped(IService, item); 
            }


            service.AddScoped<IRoleConsumeService, RoleConsumeService>();
            service.AddScoped<IUserConsumeService, UserConsumeService>();
            service.AddScoped<ICategoryConsumeService, CategoryConsumeService>();
            service.AddScoped<IAccountConsumeService, AccountConsumeService>();
            


            return service;
        }

    }
}
