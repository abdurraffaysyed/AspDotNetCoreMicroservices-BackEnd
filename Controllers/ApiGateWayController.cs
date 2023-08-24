using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiGateWayMicroservice.Controllers
{
    [Route("api/gateway/")]
    [ApiController]
    public class ApiGateWayController : ControllerBase
    {
        private readonly HttpClient client;
        public ApiGateWayController(IHttpClientFactory httpClient)
        {
            client = httpClient.CreateClient();
        }
        [HttpGet("getallproducts")]
        public async Task<ActionResult> GetProducts()
        {
            
            var response = await client.GetAsync($"http://product:80/api/products/getallproducts");
            return new ObjectResult(await response.Content.ReadAsStreamAsync());
        }
        [HttpPost("PostOrders")]
        public async Task<IActionResult> PostOrders([FromBody] dynamic requestbody)
        {
            var content = new StringContent(JsonConvert.SerializeObject(requestbody), Encoding.UTF8, "application/json");
            var typre = requestbody.GetType();
            var response = await client.PostAsync($"http://order:80/api/order/postorder", content);
            if(response.IsSuccessStatusCode)
            {
                return Ok(response);
            }
            return BadRequest();
        }
    }
}