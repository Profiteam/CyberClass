using Domain.Persons;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Response
{
    public class ProfileDTO
    {
        public long UserID { get; set; }
        public string Avatar { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Vk { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Twitch { get; set; }

        public ProfileDTO()
        {
        }

        public ProfileDTO(User profile)
        {
            if (profile == null)
                return;
            UserID = profile.ID;
            Avatar = profile.Person.Avatar;
            NickName = profile.Person.NickName;
            Email = profile.Person.Email;
            Vk = profile.Person.Vk;
            Facebook = profile.Person.Facebook;
            Instagram = profile.Person.Instagram;
            Twitch = profile.Person.Twitch;
        }
    }
}
