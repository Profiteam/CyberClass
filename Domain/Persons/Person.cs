using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Persons
{
    public class Person : PersistentObject
    {
        public virtual string PhoneNumber { get; set; }
        public virtual string Avatar { get; set; }
        public virtual string NickName { get; set; }
        public virtual string Email { get; set; }
        public virtual string Vk { get; set; }
        public virtual string Facebook { get; set; }
        public virtual string Instagram { get; set; }
        public virtual string Twitch { get; set; }
    }
}
