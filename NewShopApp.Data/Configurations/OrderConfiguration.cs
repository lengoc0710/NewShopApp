using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewShopApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewShopApp.Data.Configurations
{

    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {

        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.OrderDate); //.HasDefaultValue(DateTime.Now);
            builder.Property(x => x.ShipEmail).IsRequired().IsUnicode(false).HasMaxLength(55);
            //limit charcaters
            builder.Property(x => x.ShipAddress).IsRequired().IsUnicode(false).HasMaxLength(55);
            builder.Property(x => x.ShipName).IsRequired().IsUnicode(false).HasMaxLength(55);
            builder.Property(x => x.ShipPhoneNumber).IsRequired().IsUnicode(false).HasMaxLength(55);
           builder.HasOne(x => x.AppUser).WithMany(x => x.Orders).HasForeignKey(x => x.UserId);
        }
    }
}
