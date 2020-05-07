using Domain.Orders;
using Storage.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services
{
    public class OrderService : BaseCrudService<Order>, IOrderService
    {
        public OrderService(IRepository<Order> repository) : base(repository)
        {

        }
    }
}
