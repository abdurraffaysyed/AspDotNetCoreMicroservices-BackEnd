using Microsoft.AspNetCore.Mvc;
using OrdersMicroService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersMicroService.Repository
{
    public interface IOrdersRepo
    {
        Task<bool> PostOrder(OrderModel order);
    }
}
