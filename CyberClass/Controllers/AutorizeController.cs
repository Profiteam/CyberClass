using Domain.Persons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyberClass.Controllers
{
    [Authorize]
    public abstract class AuthorizeController : BaseController
    {
        protected readonly User user;
        public AuthorizeController(IUserService userService, IHttpContextAccessor contextAccessor)
        {
            user = userService.GetAll().First(x => x.Login == contextAccessor.HttpContext.User.Identity.Name && x.Activated == true);

        }
    }
}
