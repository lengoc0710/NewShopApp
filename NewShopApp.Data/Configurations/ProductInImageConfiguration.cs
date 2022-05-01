using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewShopApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewShopApp.Data.Configurations
{
    public class ProductInImageConfiguration : IEntityTypeConfiguration<ProductInImage>
    {
        public void Configure(EntityTypeBuilder<ProductInImage> builder)
        {

            builder.ToTable("ProductImages");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.ImagePath).HasMaxLength(200).IsRequired(true);
            builder.Property(x => x.Caption).HasMaxLength(200);// no required 

            builder.HasOne(x => x.ProductTest).WithMany(x => x.ProductImages).HasForeignKey(x => x.ProductId);
        }
    }
}
