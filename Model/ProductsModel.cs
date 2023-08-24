using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsMicroservice.Model
{
    public class ProductsModel
    {
        [Required]
        [Key]
        public string productid { get; set; }
        public string productname { get; set; }
        public int productqty { get; set; }

        public string orderid { get; set; }
    }
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            DbContextOptionsBuilder<AppDbContext> builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseMySql(config.GetConnectionString("MySqlConnection"));
            return new AppDbContext(builder.Options);
        }
    }
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public AppDbContext()
        {

        }
        public DbSet<ProductsModel> products { get; set; }
    }
}
