using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyberClass.Controllers
{
    public class LessonNotAutorizeController : BaseController
    {
        private ILessonService LessonService { get; set; }

        public LessonNotAutorizeController(
           ILessonService lessonService)
           : base()
        {
            LessonService = lessonService;
        }

        [HttpGet(nameof(GetLessonsNotAutarize))]
        public IActionResult GetLessonsNotAutarize(long matId)
          => Ok(LessonService.GetLessonsNotAutarize(matId));
    }
}
