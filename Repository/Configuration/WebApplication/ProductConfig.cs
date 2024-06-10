using Entities.Entity.WebApplication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Repository.Configuration.WebApplication
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(op => op.Name).IsRequired();
            builder.Property(op => op.Description).IsRequired();

            builder.Property(op => op.RowVersion).IsRowVersion();

        }
    }
}
