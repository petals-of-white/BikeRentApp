using System;
using Microsoft.EntityFrameworkCore;
using DataAccessLibrary.Models;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace DataAccessLibrary
{
    public class BicycleContext : DbContext
    {
        public DbSet<Bicycle> Bicycles { get; set; }
        public DbSet<BicycleType> BicycleTypes { get; set; }

     
        public BicycleContext(): base()
        {
            bool newDbCreated = this.Database.EnsureCreated();
            if (newDbCreated == true)
            {
                EFCrud.CreateSampleData();
            }
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //string pathToJson = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\..", "DataAccessLibrary"));

            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            
            IConfigurationRoot config = builder.Build();

            string connectionString = config.GetConnectionString("Default");
            
            options.UseSqlServer(connectionString);
        }
    }
}
