using Domain.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Response
{
    public class SubDTO
    {
        public long ID { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }

        public SubDTO() { }

        public SubDTO(Sub sub)
        {
            if (sub == null)
                return;
            ID = sub.ID;
            Email = sub.Email;
            Date = sub.Date;
        }
    
    }
}
