using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrdersMicroService.Model;
using OrdersMicroService.Repository;

namespace OrdersMicroService.Controllers
{
    [Route("api/order/")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IOrdersRepo repo;
        public OrdersController(IOrdersRepo order)
        {
            repo = order;
        }

        [HttpPost("postorder")]
        public async Task<IActionResult> CreateOrder(OrderModel order)
        {
            var response = await repo.PostOrder(order);
            if (response)
            {
                return Ok(order);
            }
            else
                return NoContent();
        }
    }
}