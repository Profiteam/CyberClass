using Domain.Enum;
using Domain.Ratings;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Storage.Mappings
{
    public class RatingMap : ClassMap<Rating>
    {
        public RatingMap()
        {
            Table("ratings");

            Id(u => u.ID, "id");

            Map(u => u.Date, "date");
            Map(u => u.RatingType, "rating_type").CustomType<RatingType>();


            References(u => u.User, "id_user");
            References(u => u.Material, "id_material");

            Map(u => u.Deleted, "deleted").Not.Nullable();
        }
    }
}
