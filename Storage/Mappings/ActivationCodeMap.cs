using Domain.Persons;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Storage.Mappings
{
    public class ActivationCodeMap : ClassMap<ActivationCode>
    {
        public ActivationCodeMap()
        {
            Table("activation_codes");

            Id(u => u.ID, "id");


            Map(u => u.Code, "code");
            Map(u => u.Date, "date");

            References(e => e.User, "id_user");

            Map(u => u.Deleted, "deleted").Not.Nullable();
        }
    }
}
