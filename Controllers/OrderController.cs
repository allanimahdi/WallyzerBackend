using System.Collections.Generic;
using TableauxApi.Models;
using TableauxApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace TableauxApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public ActionResult<List<Order>> Get()
        {
            return _orderService.Get();
        }

        [EnableCors("AllowOrigin")]
        [HttpPost]
        public ActionResult<Order> Create(Order order)
        {
                _orderService.Create(order);
            return order;
      //      return CreatedAtRoute("GetOrder", new { id = order._id.ToString() }, order);
        }

    }
}