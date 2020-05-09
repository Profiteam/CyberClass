using Domain.Enum;
using Domain.Materials;
using Domain.Persons;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Orders
{
	public class Order : PersistentObject
	{
		public virtual User User { get; set; }
		public virtual Material Material { get; set; }
		public virtual double AmountPay { get; set; }
		public virtual OrderStatus Status { get; set; }
		public virtual DateTime Date { get; set; }
	}
}
