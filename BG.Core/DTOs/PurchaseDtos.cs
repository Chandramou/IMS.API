using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BG.Core.DTOs
{
	public class PurchaseDtos
	{
		public int Id { get; set; }
		public int? ProductId { get; set; }
		public int? Quantity { get; set; }
		public DateTime? CreatedTime { get; set; }

		public DateTime? DeliveryTime { get; set; }

		public string? Description { get; set; }

		public bool? Confirmation { get; set; }

		public DateTime? ConfirmationTime { get; set; }
	}
}
