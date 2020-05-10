using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Persons
{
    public class ActivationCode : PersistentObject
    {
        public virtual User User { get; set; }
        public virtual string Code { get; set; }
        public virtual DateTime Date { get; set; }
    }
}
