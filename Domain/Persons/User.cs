using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Persons
{
    public class User : PersistentObject
    {
        public virtual Person Person { get; set; }
        public virtual string Login { get; set; }
        public virtual string Password { get; set; }
        public virtual UserType UserType { get; set; }
        public virtual DateTime RegistrationDate { get; set; }
        public virtual bool Activated { get; set; }
    }
}
