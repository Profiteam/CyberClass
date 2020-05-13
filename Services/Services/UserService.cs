using Domain.Persons;
using DTO.Request;
using DTO.Response;
using Storage.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Utils;

namespace Services.Services
{
    public class UserService : BaseCrudService<User>, IUserService
    {
        private IPersonService PersonService { get; set; }
        public UserService(IRepository<User> repository, IPersonService personService) : base(repository)
        {
            PersonService = personService;
        }

        public User CreateUser(CreateUserDTO createUser)
        {

            var user = new User
            {
                Login = createUser.PhoneNumber,
                Password = CryptHelper.CreateMD5(createUser.Password),
                Activated = false,
                UserType = Domain.Enum.UserType.User,
                RegistrationDate = DateTime.UtcNow,
                Person = new Person
                {
                    PhoneNumber = createUser.PhoneNumber
                }
            };

            var newUser = CreateEntity(user);
            return newUser;
        }

        public ProfileDTO EditMyProfile(EditProfileDTO request, User user)
        {
            user.Person.Email = request.Email;
            user.Person.Facebook = request.Facebook;
            user.Person.NickName = request.NickName;
            user.Person.Twitch = request.Twitch;
            user.Person.Instagram = request.Instagram;
            user.Person.Vk = request.Vk;
            PersonService.Update(user.Person);

            return new ProfileDTO(user);

        }

        public ProfileDTO GetMyProfile(User user)
        {
            return new ProfileDTO(user);
        }
    }
}
