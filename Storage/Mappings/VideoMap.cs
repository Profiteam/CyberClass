using Domain.Materials;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Storage.Mappings
{
    public class VideoMap : ClassMap<Video>
    {
        public VideoMap()
        {
            Table("videos");

            Id(u => u.ID, "id");

            Map(u => u.Format, "format");
            Map(u => u.Url, "url");

            References(u => u.Lesson, "id_lesson");

            Map(u => u.Deleted, "deleted").Not.Nullable();
        }
    }
}
