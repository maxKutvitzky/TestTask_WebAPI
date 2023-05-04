using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.DAL.Data
{
    internal class DbContextDesignTimeFactory : IDesignTimeDbContextFactory<ShopDbContext>
    {
        private readonly IConfiguration _configuration = GetConfiguration();

        private static IConfiguration GetConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory() + @"\Data\")
                .AddJsonFile("dbContextDesignTimeConfig.json")
                .Build();
        }

        public ShopDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ShopDbContext>();
            string connectionString = _configuration.GetConnectionString("Default");
            builder.UseSqlServer(connectionString);
            return new ShopDbContext(builder.Options);
        }
    }
}
