using Domain.Enum;
using Domain.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO.Response
{
    public class LessonDTO
    {
        public long ID { get; set; }
        public long MaterialID { get; set; }
        public int Number { get; set; }
        public LessonType LessonType { get; set; }
        public string Name { get; set; }
        public List<VideoDTO> Videos { get; set; }
        public string Description { get; set; }
        public double Duration { get; set; }
        public string Preview { get; set; }
        public bool IsPaid { get; set; }

        public LessonDTO() { }

        public LessonDTO(Lesson lesson, bool isPaid)
        {
            if (lesson == null)
                return;
            ID = lesson.ID;
            MaterialID = lesson.Material.ID;
            Number = lesson.Number;
            Name = lesson.Name;
            LessonType = lesson.LessonType;
            Description = lesson.Description;
            Preview = lesson.Preview;
            Duration = lesson.Duration;
            IsPaid = isPaid;          
        }

        public LessonDTO(Lesson lesson, List<VideoDTO> videos, bool isPaid)
        {
            if (lesson == null)
                return;
            ID = lesson.ID;
            MaterialID = lesson.Material.ID;
            Number = lesson.Number;
            Name = lesson.Name;
            LessonType = lesson.LessonType;
            Description = lesson.Description;
            Preview = lesson.Preview;
            Duration = lesson.Duration;
            Videos = videos;
            IsPaid = isPaid;
        }
    }
}
