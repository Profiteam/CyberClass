using Domain.Enum;
using Domain.Persons;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Storage.Mappings
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("users");

            Id(u => u.ID, "id");

            Map(u => u.Login, "login");
            Map(u => u.Password, "password");
            Map(u => u.UserType, "user_type").CustomType<UserType>();
            Map(u => u.RegistrationDate, "registration_date");
            Map(u => u.Activated, "activated").Not.Nullable();

            References(u => u.Person, "id_person").Cascade.All();

            Map(u => u.Deleted, "deleted").Not.Nullable();
        }
    }
}
