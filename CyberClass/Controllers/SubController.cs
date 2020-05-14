using DTO.Request;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyberClass.Controllers
{
    public class SubController : BaseController
    {
        private ISubService SubService { get; set; }

        public SubController(
           ISubService subService)
           : base()
        {
            SubService = subService;

        }

        [HttpPost(nameof(CreateSub))]
        public IActionResult CreateSub([FromBody] CreateSubDTO create)
          => Ok(SubService.CreateSub(create));

        [HttpGet(nameof(GetSubs))]
        public IActionResult GetSubs()
          => Ok(SubService.GetSubs());
    }
}
