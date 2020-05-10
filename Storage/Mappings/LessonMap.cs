using Domain.Enum;
using Domain.Materials;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Storage.Mappings
{
    public class LessonMap : ClassMap<Lesson>
    {
        public LessonMap()
        {
            Table("lessons");

            Id(u => u.ID, "id");

            Map(u => u.Number, "number");
            Map(u => u.Name, "name");
            Map(u => u.Preview, "preview");
            Map(u => u.Url, "url");
            Map(u => u.Description, "description");
            Map(u => u.LessonType, "lesson_type").CustomType<LessonType>();
            Map(u => u.Duration, "duration");

            References(u => u.Material, "id_material");

            Map(u => u.Deleted, "deleted").Not.Nullable();
        }
    }
}
