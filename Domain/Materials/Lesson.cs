using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Materials
{
    public class Lesson: PersistentObject
    {
        public virtual Material Material { get; set; }
        public virtual LessonType LessonType { get; set; }
        public virtual int Number { get; set; }
        public virtual string Name { get; set; }
        public virtual string Url { get; set; }
        public virtual string Description { get; set; }
        public virtual double Duration { get; set; }
    }
}
