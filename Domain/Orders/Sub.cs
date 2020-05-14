using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Orders
{
    public class Sub: PersistentObject
    {
        public virtual string Email { get; set; }
        public virtual DateTime Date { get; set; }
    }
}
