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
        private IUserService UserService { get; set; }

        public LessonController(IUserService userService,
           IHttpContextAccessor contextAccessor,
           IOrderService orderService)
           : base(userService, contextAccessor)
        {
            OrderService = orderService;
            UserService = userService;
        }

        [HttpGet(nameof(GetLessonsNotAutarize))]
        public IActionResult GetLessonsNotAutarize(long matId)
          => Ok(OrderService.GetLessons(matId, user));

    }
}
