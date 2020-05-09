using Domain.Enum;
using Domain.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Response
{
    public class OrderDTO
    {
        public long UserId { get; set; }
        public long MaterialId { get; set; }
        public double AmountPay { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime Date { get; set; }

        public OrderDTO() { }

        public OrderDTO(Order order)
        {
            if (order == null)
                return;
            UserId = order.User.ID;
            MaterialId = order.Material.ID;
            Status = order.Status;
            Date = order.Date;
        }
    }
}
