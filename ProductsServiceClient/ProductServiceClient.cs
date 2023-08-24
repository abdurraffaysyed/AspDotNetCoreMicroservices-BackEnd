using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OrdersMicroService.Model;

namespace OrdersMicroService.ProductsServiceClient
{
    public class ProductServiceClient : IProductServiceClient
    {
        private string conn;
        private HttpClient clients;
        public ProductServiceClient(IConfiguration config, IHttpClientFactory clientFactory)
        {
            conn = config.GetConnectionString("ProductsClient");
            clients = clientFactory.CreateClient();
        }

        public async Task<IEnumerable<ProductsModelDTO>> GetProducts()
        {
            List<ProductsModelDTO> products = new List<ProductsModelDTO>();
            var response = await clients.GetAsync($"{conn}/products/getallproducts");
            
            products = await response.Content.ReadAsAsync<List<ProductsModelDTO>>();
            return products;

            
        }
    }
}
