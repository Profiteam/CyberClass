using Domain.Enum;
using Domain.Persons;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Response
{
    public class UserDTO
    {
        public long UserID { get; set; }
        public PersonDTO Person { get; set; }
        public UserType UserType { get; set; }
        public string NickName { get; set; }
        public string Avatar { get; set; }

        public UserDTO()
        {
        }

        public UserDTO(User user)
        {
            if (user == null)
                return;
            UserID = user.ID;
            UserType = user.UserType;
            Person = new PersonDTO(user.Person);
            NickName = user.Person.NickName;
            Avatar = user.Person.Avatar;
        }
    }
}
