using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewShopApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewShopApp.Data.Configuration
{
    public class AppConfigConfiguration : IEntityTypeConfiguration<AppConfig>
    {
        public void Configure(EntityTypeBuilder<AppConfig> builder)
        {
            builder.ToTable("AppConfigs");
            //Configurations of properties, SQL table
            builder.HasKey(x => x.Key);
            //primary key
            builder.Property(x => x.Value).IsRequired(true);
            // Input x
        }
    }
}
