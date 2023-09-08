using System;
using Core.Entities;

namespace Entities
{
	public class Order:IEntity
	{
		public Order()
		{
		}

		public int OrderId { get; set; }
	}
}

