using Domain.Materials;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Storage.Mappings
{
    public class MaterialMap : ClassMap<Material>
    {
        public MaterialMap()
        {
            Table("materials");

            Id(u => u.ID, "id");

            Map(u => u.Number, "number");
            Map(u => u.Name, "name");
            Map(u => u.Price, "price");
            Map(u => u.Description, "description");
            Map(u => u.TotalDuration, "total_duration");

            Map(u => u.Deleted, "deleted").Not.Nullable();
        }
    }
}
