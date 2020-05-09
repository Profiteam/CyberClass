using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyberClass.Controllers
{
    public class NotAutorizeController : BaseController
    {
        private ILessonService LessonService { get; set; }
        private IRatingService RatingService { get; set; }

        public NotAutorizeController(
           ILessonService lessonService, IRatingService ratingService)
           : base()
        {
            LessonService = lessonService;
            RatingService = ratingService;
        }

        [HttpGet(nameof(GetLessonsNotAutarize))]
        public IActionResult GetLessonsNotAutarize(long matId)
          => Ok(LessonService.GetLessonsNotAutarize(matId));

        [HttpGet(nameof(GetMaterialsNotAutorize))]
        public IActionResult GetMaterialsNotAutorize()
          => Ok(RatingService.GetMaterialsNotAutorize());
    }
}
