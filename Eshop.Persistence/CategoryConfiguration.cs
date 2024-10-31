using Eshop.Domain;
using Microsoft.EntityFrameworkCore;

namespace Eshop.Persistence
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name);
        }
    }
}
