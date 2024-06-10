using Entities.Entity.WebApplication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Repository.Configuration.WebApplication
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(op => op.Name).IsRequired();
            builder.Property(op => op.RowVersion).IsRowVersion();


        }
    }
}
