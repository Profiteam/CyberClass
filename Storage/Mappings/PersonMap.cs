using Domain.Persons;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Storage.Mappings
{
    public class PersonMap : ClassMap<Person>
    {
        public PersonMap()
        {
            Table("persons");

            Id(u => u.ID, "id");

            Map(u => u.PhoneNumber, "phone_number");
            Map(u => u.NickName, "nick_name");
            Map(u => u.Avatar, "avatar");
            Map(u => u.Email, "email");
            Map(u => u.Vk, "vk");
            Map(u => u.Instagram, "instagram");
            Map(u => u.Facebook, "facebook");
            Map(u => u.Twitch, "twitch");

            Map(u => u.Deleted, "deleted").Not.Nullable();
        }
    }
}
