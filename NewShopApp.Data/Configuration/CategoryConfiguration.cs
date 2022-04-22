using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewShopApp.Data.Entities;
using NewShopApp.Data.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewShopApp.Data.Configuration
{
    class CategoryConfiguration : IEntityTypeConfiguration<CategoryTest>
    {
      
        public void Configure(EntityTypeBuilder<CategoryTest> builder)
        {
            builder.ToTable("CategorieTests");

            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID).UseIdentityColumn();


            builder.Property(x => x.Status).HasDefaultValue(Status.Active);
        }
    }
}
