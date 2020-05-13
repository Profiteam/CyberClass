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
    public class ProfileController : AuthorizeController
    {
        private IPersonService PersonService { get; set; }
        private IUserService UserService { get; set; }

        public ProfileController(IUserService userService,
           IHttpContextAccessor contextAccessor,
           IPersonService personService)
           : base(userService, contextAccessor)
        {
            PersonService = personService;
            UserService = userService;
        }

        [HttpGet(nameof(GetMyProfile))]
        public IActionResult GetMyProfile()
          => Ok(UserService.GetMyProfile(user));

        [HttpPost(nameof(EditMyProfile))]
        public IActionResult EditMyProfile([FromBody] EditProfileDTO request)
          => Ok(UserService.EditMyProfile(request, user));

        [HttpPost (nameof(SetAvatar))]
        public async Task<IActionResult> SetAvatar(IFormFile file) =>
            Ok(await PersonService.SetAvatar(file, user));

    }
}
