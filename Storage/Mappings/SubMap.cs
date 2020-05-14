using Domain.Orders;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Storage.Mappings
{
    public class SubMap : ClassMap<Sub>
    {
        public SubMap()
        {
            Table("subs");

            Id(u => u.ID, "id");

            Map(u => u.Email, "email");
            Map(u => u.Date, "date");

            Map(u => u.Deleted, "deleted").Not.Nullable();
        }
    }
}
