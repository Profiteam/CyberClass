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

        public LessonController(IUserService userService, IRatingService ratingService,
           IHttpContextAccessor contextAccessor,
           IOrderService orderService)
           : base(userService, contextAccessor)
        {
            OrderService = orderService;
            UserService = userService;
            RatingService = ratingService;
        }

        [HttpGet(nameof(GetLessons))]
        public IActionResult GetLessons(long matId)
          => Ok(OrderService.GetLessons(matId, user));

        [HttpGet(nameof(GetMaterials))]
        public IActionResult GetMaterials()
          => Ok(RatingService.GetMaterials(user));

    }
}
