using DTO.Request;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyberClass.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAccountService accountService;
        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }



        [HttpPost(nameof(AuthUser))]
        public IActionResult AuthUser([FromBody]AuthRequest authRequest)
            => Ok(accountService.AuthUser(authRequest.Login, authRequest.Password));

        [HttpPost(nameof(AuthAdmin))]
        public IActionResult AuthAdmin([FromBody]AuthRequest authRequest)
            => Ok(accountService.AuthAdmin(authRequest.Login, authRequest.Password));

        [HttpPost(nameof(RegisterUser))]
        public IActionResult RegisterUser([FromBody]CreateUserDTO request)
            => Ok(accountService.RegisterUser(request));


    }
}
