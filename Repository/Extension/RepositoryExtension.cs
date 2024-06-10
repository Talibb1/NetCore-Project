using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.DbContext;
using Repository.GenericRepository.Abstract;
using Repository.GenericRepository.Concrete;
using Repository.UnitOfWork.Abstract;




namespace Repository.Extension
{
    public static class RepositoryExtension
    {
        public static IServiceCollection LoadRepository(this IServiceCollection service,IConfiguration config)
        {
       
            service.AddDbContext<AppDbContext>(option => option.UseSqlServer(config.GetConnectionString("SqlConnection")));


            //add generic repositorySqlConnection
            service.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
           service.AddScoped(typeof(IPagingGenericRepositry<>),typeof(PagingGenericRepositry<>));  
            
            //add unitOfWork
            service.AddScoped<IUnitOfWork, Repository.UnitOfWork.Concrete.UnitOfWork>();


            return service;
        }

    }
}
