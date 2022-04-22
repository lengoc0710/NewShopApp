using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewShopApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewShopApp.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<ProductTest>
    {
        public void Configure(EntityTypeBuilder<ProductTest> builder)
        {
            builder.ToTable("ProductTests");

            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).UseIdentityColumn();


            builder.Property(x => x.Price).IsRequired();

            builder.Property(x => x.OriginalPrice).IsRequired();

            builder.Property(x => x.Stock).IsRequired().HasDefaultValue(0);
            //set default value
            builder.Property(x => x.ViewCount).IsRequired().HasDefaultValue(0);
        }
    }
}
