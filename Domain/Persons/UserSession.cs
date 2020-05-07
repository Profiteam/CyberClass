using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Persons
{
    public class UserSession : PersistentObject
    {
        public virtual User User { get; set; }
        public virtual string Token { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual DateTime ExpiredDate { get; set; }

    }
}
