using Entities.Entity.Identity;
using Entities.Entity.WebApplication;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace Repository.DbContext
{
    public class AppDbContext:IdentityDbContext<AppUser,AppRole,string>
    {
        public AppDbContext() { }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("DataBase=NetCore;Server=DESKTOP-PTF7173;Trusted_Connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }

    }
}
