using AutoMapper;

using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.Extension;
using Service.Extension.Identity;
using Service.Extension.WebApplication;
using Service.FluentValidation.Identity.AccountValidation;
using Service.FluentValidation.Identity.UserValidation;
using Service.FluentValidation.WebApplication.ProductValidation;
using Service.Helper.Abstract;
using Service.Helper.Concrete;
using ServiceEntityLayer.FluentValidation.Identity.AccountValidation;
using ServiceEntityLayer.FluentValidation.Identity.RoleValidation;
using ServiceEntityLayer.FluentValidation.WebApplication.CategoryValidation;
using System.Reflection;


namespace Service.Extension
{
    public static class ServiceExtension
    {

        public static IServiceCollection LoadService(this IServiceCollection service,IConfiguration config)
        {
            //add All Extension
            service.LoadRepository(config);
            service.LoadWebApplication();
            service.LoadIdentity(config);

            //add AutoMapper
            service.AddAutoMapper(Assembly.GetExecutingAssembly());


            //add FluentValidation
            service.AddFluentValidationAutoValidation(op =>
            {
                op.DisableDataAnnotationsValidation = true;
            });

            service.AddValidatorsFromAssemblyContaining<RoleAddValidation>();
            service.AddValidatorsFromAssemblyContaining<RoleUpdateValidation>();

            service.AddValidatorsFromAssemblyContaining<UserAddValidation>();
            service.AddValidatorsFromAssemblyContaining<UserUpdateValidation>();

            service.AddValidatorsFromAssemblyContaining<LoginValidation>();
            service.AddValidatorsFromAssemblyContaining<SignupValidation>();
            service.AddValidatorsFromAssemblyContaining<ForgetPasswordValidation>();
            service.AddValidatorsFromAssemblyContaining<ResetPasswordValidation>();


            service.AddValidatorsFromAssemblyContaining<CategoryAddValidation>();
            service.AddValidatorsFromAssemblyContaining<CategoryUpdateValidation>();

            service.AddValidatorsFromAssemblyContaining<ProductAddValidation>();
            service.AddValidatorsFromAssemblyContaining<ProductUpdateValidation>();


            //add Helper
            service.AddScoped<IPagerHelper, PagerHelper>();
            service.AddScoped<ISendEmailHelper, SendEmailHelper>();


            //add HttpClient
            service.AddHttpClient();

            return service;
        }
    }
}
