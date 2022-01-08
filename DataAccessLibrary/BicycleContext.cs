using System;
using Microsoft.EntityFrameworkCore;
using DataAccessLibrary.Models;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DataAccessLibrary
{
    public class BicycleContext : DbContext
    {
        public DbSet<Bicycle> Bicycles { get; set; }
        public DbSet<BicycleType> BicycleTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            string pathToJson = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\..", "DataAccessLibrary"));

            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(pathToJson)
                .AddJsonFile("dbsettings.json");
            
            IConfigurationRoot config = builder.Build();

            options.UseSqlServer(config.GetConnectionString("Default"));
        }
    }
}
