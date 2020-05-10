using Domain.Persons;
using DTO.Request;
using Storage.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Utils;

namespace Services.Services
{
    public class UserService : BaseCrudService<User>, IUserService
    {
        public UserService(IRepository<User> repository) : base(repository)
        {

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
    }
}
