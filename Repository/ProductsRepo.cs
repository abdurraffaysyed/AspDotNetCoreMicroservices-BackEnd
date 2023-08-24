using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsMicroservice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsMicroservice.Repository
{
    public class ProductsRepo : IProductsRepo
    {
        private AppDbContext options;
        public ProductsRepo(AppDbContext context)
        {
            options = context;
        }
        public async Task<ActionResult<IEnumerable<ProductsModel>>> GetAllProducts()
        {
            return await options.products.ToListAsync();
        }
        public async Task<ActionResult<ProductsModel>> CreateProduct(ProductsModel products)
        {
            await options.products.AddAsync(products);
            await options.SaveChangesAsync();
            return products;
        }
    }
}
