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
    public class RatingController : AuthorizeController
    {
        private IRatingService RatingService { get; set; }
        private IUserService UserService { get; set; }

        public RatingController(IUserService userService, IRatingService ratingService,
           IHttpContextAccessor contextAccessor)
           : base(userService, contextAccessor)
        {
            UserService = userService;
            RatingService = ratingService;
        }

        [HttpPost(nameof(CreateRating))]
        public IActionResult CreateRating([FromBody] CreateRatingDTO request)
          => Ok(RatingService.CreateRating(request, user));
    }
}