using Domain.Enum;
using Domain.Materials;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Response
{
    public class LessonNotAuthDTO
    {
        public long ID { get; set; }
        public long MaterialID { get; set; }
        public int Number { get; set; }
        public LessonType LessonType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Preview { get; set; }
        public double Duration { get; set; }

        public LessonNotAuthDTO() { }

        public LessonNotAuthDTO(Lesson lesson)
        {
            if (lesson == null)
                return;
            ID = lesson.ID;
            MaterialID = lesson.Material.ID;
            Number = lesson.Number;
            Name = lesson.Name;
            LessonType = lesson.LessonType;
            Description = lesson.Description;
            Duration = lesson.Duration;
            Preview = lesson.Preview;
        }
    }
}
