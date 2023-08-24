using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsMicroservice.Model;
using ProductsMicroservice.Repository;

namespace ProductsMicroservice.Controllers
{
    [Route("api/products/")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductsRepo productsrepo;
        public ProductsController(IProductsRepo repo)
        {
            productsrepo = repo;
        }
        [HttpGet("getallproducts")]
        public async Task<ActionResult<IEnumerable<ProductsModel>>> GetAllProducts()
        {
            //return Content("lolo","text/plain");
            return await productsrepo.GetAllProducts();
        }

        [HttpPost("CreateProducts")]
        public async Task<ActionResult<ProductsModel>> CreateProduct(ProductsModel products)
        {
            var resposne = await productsrepo.CreateProduct(products);
            return resposne;
        }
    }
}