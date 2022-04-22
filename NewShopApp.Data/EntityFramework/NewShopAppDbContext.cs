
//using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NewShopApp.Data.Configuration;
using NewShopApp.Data.Entities;
using SolutionTest2.Data.Configurations;
using System;
using System.Collections.Generic;
using System.Text;
//using SolutionTest2.Data.Configurations;
//using SolutionTest2.Data.Extensions;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SolutionTest2.Data.EntityFramework
{
    public class NewShopAppDbContext : DbContext
       // IdentityDbContext<AppUser,AppRole,Guid>
    {
        public NewShopAppDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new AppConfigConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductInCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
            modelBuilder.ApplyConfiguration(new CartConfiguration());
            modelBuilder.ApplyConfiguration(new PromotionConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryTranslationConfiguration());
            modelBuilder.ApplyConfiguration(new ProductTranslationConfiguration());
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            modelBuilder.ApplyConfiguration(new LanguageConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());

            //modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            //modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
            //modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims");
            //modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles").HasKey(x => new { x.UserId, x.RoleId });
            //modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins").HasKey(x => x.UserId);
            //modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims");
            //modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens").HasKey(x => x.UserId);

            ////.HasKey(x => new { x.UserId, x.RoleId })
            ////  .HasKey(x => x.UserId)
            //// .HasKey(x => x.UserId)
            //modelBuilder.Seed();

            // base.OnModelCreating(modelBuilder); add-migration AspNetCoreIdentityData
            //add own configuration
            //}
        }

        public DbSet<ProductTest> Products { get; set; }
        public DbSet<CategoryTest> Categories { get; set; }

        public DbSet<AppConfig> AppConfigs { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<CategoryTranslation> CategoryTranslations { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<OrderDetail> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<ProductTranslation> ProductTranslations { get; set; }

        public DbSet<Promotion> Promotions { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

      //  public DbSet<ProductImage> ProductImages { get; set; }

      //  public DbSet<Slide> Slides { get; set; }
    }
}