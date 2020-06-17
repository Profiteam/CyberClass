using Domain.Enum;
using Domain.Persons;
using DTO.Request;
using DTO.Response;
using Microsoft.IdentityModel.Tokens;
using SmsRu;
using Storage.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Utils;

namespace Services.Services
{
    public class AccountService : BaseCrudService<UserSession>, IAccountService
    {
        private readonly IUserService userService;
        private readonly IActivationCodeService activationCodeService;


        public AccountService(IRepository<UserSession> repository, IActivationCodeService activationCodeService,
            IUserService userService) : base(repository)
        {
            this.activationCodeService = activationCodeService;
            this.userService = userService;
        }

        public SignInDTO AuthAdmin(string login, string password)
        {
            var admin = userService.GetAll().FirstOrDefault(x =>
                x.Login == login && x.UserType == UserType.Admin &&
                x.Password == CryptHelper.CreateMD5(password));
            if (admin == null)
                throw new ServiceErrorException(706);
            var identity = GetIdentity(admin);
            var token = GetSecurityToken(identity, false);
            return new SignInDTO(admin, token);
        }

        public bool AuthUser(AuthRequest authRequest)
        {
            var user = userService.GetAll().FirstOrDefault(x =>
                x.Login == authRequest.Login && x.UserType == UserType.User &&
                x.Password == CryptHelper.CreateMD5(authRequest.Password));

            if (user == null)
                throw new ServiceErrorException(106);
            if (string.IsNullOrEmpty(authRequest.Login))
                throw new ServiceErrorException(2);

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
            activationCodeService.Create(activationCode);

            return true;
        }

        public SignInDTO CheckCode(string login, string code)
        {
            if (string.IsNullOrEmpty(code))
                throw new ServiceErrorException(2);

            if (string.IsNullOrEmpty(login))
                throw new ServiceErrorException(2);

            var user = userService.GetAll().FirstOrDefault(x => x.Login.Equals(login));
            if (user == null)
                throw new ServiceErrorException(106);

            var activationCode = activationCodeService.GetAll().FirstOrDefault(x => x.Code.Equals(code) && x.User.ID == user.ID);
            if (activationCode == null)
                throw new ServiceErrorException(300);

            user.Activated = true;
            userService.Update(user);

            var identity = GetIdentity(user);
            var token = GetSecurityToken(identity, false);

            return new SignInDTO(user, token);
        }

        public UserDTO RegisterUser(CreateUserDTO createUser)
        {
            var user = userService.GetAll().FirstOrDefault(x => x.Login.Equals(createUser.PhoneNumber));
            if (user != null)
                throw new ServiceErrorException(101);

            user = userService.CreateUser(createUser);

            return new UserDTO(user);
        }


        private ClaimsIdentity GetIdentity(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, "user")
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            return claimsIdentity;
        }

        private SecurityTokenViewModel GetSecurityToken(ClaimsIdentity identity, bool remember)
        {
            var now = DateTime.UtcNow;
            var expires = now;

            if (remember)
                expires = DateTime.MaxValue;
            else
                expires = now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME));

            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: expires,
                    signingCredentials: new SigningCredentials(
                        AuthOptions.GetSymmetricSecurityKey(),
                        SecurityAlgorithms.HmacSha256)
                    );

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new SecurityTokenViewModel(encodedJwt, expires);
        }
    }

    public class AuthOptions
    {
        public const string ISSUER = "poker-auth-server"; // издатель токена
        public const string AUDIENCE = "http://localhost:5000/"; // потребитель токена
        const string KEY = "jd645JHkdH348t2hjf3ujd4wk";   // ключ для шифрации
        public const int LIFETIME = 120000; // время жизни токена - 120 минут
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
