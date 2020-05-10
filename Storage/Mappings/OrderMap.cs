using Domain.Enum;
using Domain.Orders;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Storage.Mappings
{
    public class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {
            Table("orders");

            Id(u => u.ID, "id");

            Map(u => u.AmountPay, "amount_pay");
            Map(u => u.Date, "date");
            Map(u => u.Status, "status").CustomType<OrderStatus>();

            References(u => u.User, "id_user");
            References(u => u.Material, "id_material");

            Map(u => u.Deleted, "deleted").Not.Nullable();
        }
    }
}
