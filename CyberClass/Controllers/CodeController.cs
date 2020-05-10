using Domain.Persons;
using Microsoft.AspNetCore.Mvc;
using Services;
using SmsRu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyberClass.Controllers
{
    public class CodeController : BaseController
    {
        private IUserService UserService { get; set; }
        private IActivationCodeService ActivationCodeService { get; set; }
        public CodeController([FromServices]
            IUserService userService,
            IActivationCodeService activationCodeService)

        {
            UserService = userService;
            ActivationCodeService = activationCodeService;
        }

        [HttpGet(nameof(SendActivationCode))]
        public IActionResult SendActivationCode(string login)
        {
            if (string.IsNullOrEmpty(login))
                throw new ServiceErrorException(2);

            var user = UserService.GetAll().FirstOrDefault(x => x.Login.Equals(login));
            if (user == null)
                throw new ServiceErrorException(106);

            ISmsProvider sms = new SmsRuProvider();

            Random rnd = new Random();
            int randomNumber = rnd.Next(100000, 999999);

            sms.Send(null, user.Login, randomNumber.ToString());

            var activationCode = new ActivationCode
            {
                User = user,
                Code = randomNumber.ToString(),
                Date = DateTime.UtcNow
            };
            ActivationCodeService.Create(activationCode);

            return Ok(true);
        }

        [HttpGet(nameof(CheckCode))]
        public IActionResult CheckCode(string code, string login)
        {
            if (string.IsNullOrEmpty(code))
                throw new ServiceErrorException(2);

            if (string.IsNullOrEmpty(login))
                throw new ServiceErrorException(2);

            var user = UserService.GetAll().FirstOrDefault(x => x.Login.Equals(login));
            if (user == null)
                throw new ServiceErrorException(106);

            var activationCode = ActivationCodeService.GetAll().FirstOrDefault(x => x.Code.Equals(code) && x.User.ID == user.ID);
            if (activationCode == null)
                throw new ServiceErrorException(300);

            user.Activated = true;
            UserService.Update(user);

            return Ok();
        }
    }
}
