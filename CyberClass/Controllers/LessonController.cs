using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyberClass.Controllers
{
    public class LessonController : AuthorizeController
    {
        private IOrderService OrderService { get; set; }
        private IRatingService RatingService { get; set; }
        private IUserService UserService { get; set; }
        private IHttpContextAccessor ContextAccessor { get; set; }

        public LessonController(IUserService userService, IRatingService ratingService,
           IHttpContextAccessor contextAccessor,
           IOrderService orderService)
           : base(userService, contextAccessor)
        {
            OrderService = orderService;
            UserService = userService;
            RatingService = ratingService;
            ContextAccessor = contextAccessor;
        }

        [HttpGet(nameof(GetLessons))]
        public IActionResult GetLessons(long matId)
        {
            string ipAddress = ContextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();

          return Ok(OrderService.GetLessons(matId, ipAddress, user));
        }
        

        [HttpGet(nameof(GetMaterials))]
        public IActionResult GetMaterials()
          => Ok(RatingService.GetMaterials(user));

        [HttpGet(nameof(GetPaidLessons))]
        public IActionResult GetPaidLessons(long matId)
        {
            string ipAddress = ContextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            return Ok(OrderService.GetPaidLessons(user, matId, ipAddress));
        }
        

    }
}
