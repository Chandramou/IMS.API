using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BG.Core.DTOs
{
	public class OrderDtos
	{
		public int Id { get; set; }

		public int? ProductId { get; set; }

		public DateTime? OrderDate { get; set; }

		public DateTime? ConfirmDate { get; set; }

		public bool? ConfirmStatus { get; set; }

		public string? ShippingAddress { get; set; }
	}
}
