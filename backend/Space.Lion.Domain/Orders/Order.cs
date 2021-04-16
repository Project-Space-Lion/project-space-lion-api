using System;
using System.Collections.Generic;
using System.Linq;
using SPace.Lion.Domain.Orders;

namespace Space.Lion.Domain.Orders
{
	public class Order
	{
		public int Id { get; set; }
		public List<OrderItem> Items { get; set; }
		public DateTime CreatedDate { get; set; }
		public decimal TotalPrice => Items.Sum(i => i.Price);

	}
}