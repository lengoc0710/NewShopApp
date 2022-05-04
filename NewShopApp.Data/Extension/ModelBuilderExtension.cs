//using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NewShopApp.Data.Entities;
using NewShopApp.Data.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewShopApp.Data.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppConfig>().HasData(
                new AppConfig() { Key = "HomeTitle", Value = "This is homepage of SolutionTest" },
             new AppConfig() { Key = "HomeKeyword", Value = "This is  keyword of SolutionTest" },
            new AppConfig() { Key = "HomeDescription", Value = "This is description of SolutionTest" });
            modelBuilder.Entity<Language>().HasData(
            new Language() { Id = "vi", Name = "Tiếng Việt", IsDefault = true },
            new Language() { Id = "en", Name = "English", IsDefault = false }
            );


            modelBuilder.Entity<CategoryTest>().HasData(
              new CategoryTest()
              {
                  ID = 1,
                  OnHome = true,
                  ParentID = null,
                  SortOrder = 1,
                  Status = Status.Active,
                  //CategoryTranslations = new List<CategoryTranslation>() {
                  //new CategoryTranslation() { Id = 1, CategoryId = 1, Name = "Áo nam", LanguageId = "vi", SeoAlias = "ao-nam", SeoDescription = "Sản phẩm áo thời trang nam", SeoTitle = "Sản phẩm áo thời trang nam" },
                  //new CategoryTranslation() { Id = 2, CategoryId = 1, Name = "Men Shirt", LanguageId = "en", SeoAlias = "men-shirt", SeoDescription = "The shirt products for men", SeoTitle = "The shirt products for men" },
                  //}

              },
               new CategoryTest()
               {
                   ID = 2,
                   OnHome = true,
                   ParentID = null,
                   SortOrder = 2,
                   Status = Status.Active,
                   //  CategoryTranslations = new List<CategoryTranslation>()

                   //    new CategoryTranslation() { Id = 3, CategoryId = 2, Name = "Áo nữ", LanguageId = "vi", SeoAlias = "ao-nu", SeoDescription = "Sản phẩm áo thời trang nữ", SeoTitle = "Sản phẩm áo thời trang women" },
                   //    new CategoryTranslation() { Id = 4, CategoryId = 2, Name = "Women Shirt", LanguageId = "en", SeoAlias = "women-shirt", SeoDescription = "The shirt products for women", SeoTitle = "The shirt products for women" }
                   //}
                   //}

               }
               );


            modelBuilder.Entity<CategoryTranslation>().HasData(
                new CategoryTranslation() { Id = 1, CategoryId = 1, Name = "Áo nam", LanguageID = "vi", SeoAlias = "ao-nam", SeoDescription = "Sản phẩm áo thời trang nam",SeoTitle = "Sản phẩm áo thời trang nam" },
                new CategoryTranslation() { Id = 2, CategoryId = 1, Name = "Men Shirt", LanguageID = "en", SeoAlias = "men-shirt", SeoDescription = "The shirt products for men", SeoTitle = "The shirt products for men" },
                new CategoryTranslation() { Id = 3, CategoryId = 2, Name = "Áo nữ", LanguageID = "vi", SeoAlias = "ao-nu", SeoDescription = "Sản phẩm áo thời trang nữ" , SeoTitle = "Sản phẩm áo thời trang women" },
                new CategoryTranslation() { Id = 4, CategoryId = 2, Name = "Women Shirt", LanguageID = "en", SeoAlias = "women-shirt", SeoDescription = "The shirt products for women" ,SeoTitle = "The shirt products for women" }
                  );





            modelBuilder.Entity<ProductTest>().HasData(
          new ProductTest()
          {
              ID = 1,
              DateCreated = DateTime.Now,
              OriginalPrice = 100000,
              Price = 200000,
              Stock = 0,
              ViewCount = 0,
          });
            modelBuilder.Entity<ProductTranslation>().HasData(
                 new ProductTranslation()
                 {
                     Id = 1,
                     ProductId = 1,
                     LanguageID = "vi",
                     Name = "Áo sơ mi nam trắng hiện đại",
                     SeoAlias = "ao-so-mi-nam-trang-hien-dai ",
                     SeoDescription = "Áo sơ mi nam trắng hiện đại ",
                     SeoTitle = "Áo sơ mi nam trắng hiện đại ",
                     Details = "Áo sơ mi nam trắng hiện đại",
                     Description = "Áo sơ mi nam trắng hiện đại "
                 },
                      new ProductTranslation()
                      {
                          Id = 2,
                          ProductId = 1,
                          LanguageID = "en",
                          Name = "Modern men T-Shirt",
                          SeoAlias = "modern-men-t-shirt",
                          SeoDescription = "Modern Men T-Shirt",
                        SeoTitle = "Modern Men T-Shirt",
                          Details = "Modern Men T-Shirt",
                          Description = "Modern Men T-Shirt"
                      });


            modelBuilder.Entity<ProductInCategory>().HasData(
                    new ProductInCategory() { ProductId = 1, CategoryId = 1 }
                    );

            //// any guid
            var roleId = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC");
            var adminId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE");

            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleId,
                Name = "AdminOfWeb",
                NormalizedName = "admin",
                DescriptionOfRole = "Administrator role"
            });

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                UserName = "AdminOfWeb",
                NormalizedUserName = "admin",
                Email = "quanngoc2026@gmail@gmail.com",
                NormalizedEmail = "quanngoc2026@gmail@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "ngoc07102000"),
                SecurityStamp = string.Empty,
                FirstName = "Ngoc",
                LastName = "Le",
                Dob = new DateTime(2000, 07, 10)
            });
            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });

        }
    }
}
