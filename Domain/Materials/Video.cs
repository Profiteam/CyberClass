using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Materials
{
    public class Video : PersistentObject
    {
        public virtual Lesson Lesson { get; set; }
        public virtual string Format { get; set; }
        public virtual string Url { get; set; }
    }
}
