using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Materials
{
    public class Material: PersistentObject
    {
        public virtual int Number { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual double Price { get; set; }
        public virtual double TotalDuration { get; set; }
    }
}
