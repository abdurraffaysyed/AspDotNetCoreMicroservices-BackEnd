using Microsoft.AspNetCore.Mvc;
using ProductsMicroservice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsMicroservice.Repository
{
    public interface IProductsRepo
    {
        Task<ActionResult<IEnumerable<ProductsModel>>> GetAllProducts();
        Task<ActionResult<ProductsModel>> CreateProduct(ProductsModel products);
    }
}
