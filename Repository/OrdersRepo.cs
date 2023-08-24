using Microsoft.AspNetCore.Mvc;
using OrdersMicroService.Model;
using OrdersMicroService.ProductsServiceClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersMicroService.Repository
{
    public class OrdersRepo : IOrdersRepo
    {
        private AppDbContext context;
        private IProductServiceClient serviceclient;
        public OrdersRepo(AppDbContext option, IProductServiceClient client)
        {
            context = option;
            serviceclient = client;
        }
        public async Task<bool> PostOrder(OrderModel order)
        {
            var response = serviceclient.GetProducts();
            
            if (response.Result.Any())
            {
                var resp = await context.orders.AddAsync(order);
                await context.SaveChangesAsync();
                return true;
            }
            else
                return false;


        }
    }
}
