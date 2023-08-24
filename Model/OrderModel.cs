using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace OrdersMicroService.Model
{
    public class OrderModel
    {
        [Required]
        [Key]
        public string orderid { get; set; }
        public string customername { get; set; }
        public List<ProductsModelDTO> products { get; set; } = new List<ProductsModelDTO>();
    }
    
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<OrderModel>().HasMany(o => o.products).WithOne().HasForeignKey(key => key.orderid);
        }
        public DbSet<OrderModel> orders { get; set; }
    }
}
