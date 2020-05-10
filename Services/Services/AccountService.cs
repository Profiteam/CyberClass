using Domain.Enum;
using Domain.Persons;
using DTO.Request;
using DTO.Response;
using Microsoft.IdentityModel.Tokens;
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


        public AccountService(IRepository<UserSession> repository,
            IUserService userService) : base(repository)
        {
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

        public SignInDTO AuthUser(string login, string password)
        {
            var user = userService.GetAll().FirstOrDefault(x =>
                x.Login == login && x.UserType == UserType.User &&
                x.Password == CryptHelper.CreateMD5(password));

            if (user == null)
                throw new ServiceErrorException(106);


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
