using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NewShopApp.Data.EntityFramework
{
   public  class NewShopAppDbContextFactory : IDesignTimeDbContextFactory<NewShopAppDbContext>
    {
        public NewShopAppDbContext CreateDbContext(string[] args)
        {

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("NewShopAppDb");

            var optionsBuilder = new DbContextOptionsBuilder<NewShopAppDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new NewShopAppDbContext(optionsBuilder.Options);
        }
    }
}
