using DTO.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyberClass.Controllers
{
    public class OrderController : AuthorizeController
    {
        private IOrderService OrderService { get; set; }
        private IUserService UserService { get; set; }

        public OrderController(IUserService userService,
           IHttpContextAccessor contextAccessor,
           IOrderService orderService)
           : base(userService, contextAccessor)
        {
            OrderService = orderService;
            UserService = userService;
        }

        [HttpPost(nameof(CreateOrder))]
        public IActionResult CreateOrder([FromBody] CreateOrderDTO request)
          => Ok(OrderService.CreateOrder(request, user));

    }
}
