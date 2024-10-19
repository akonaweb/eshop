﻿using Eshop.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eshop.Persistence
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasNoKey();
            builder.Property(x => x.Id);
            builder.Property(x => x.Title);
            builder.Property(x => x.Description);
            builder.Property(x => x.Price);
            builder.Ignore(x => x.Category);
            builder.ToTable("Product");
        }
    }
}