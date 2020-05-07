using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Persons
{
    public class Person : PersistentObject
    {
        public virtual string Name { get; set; }
    }
}
