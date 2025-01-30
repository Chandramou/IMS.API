using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BG.Core.DTOs
{
	public class ProductDetailsDtos : ProductDtos
	{
		public string CategoryName { get; set; } = null!;
		public string? Description { get; set; }
		public DateTime? OrderDate { get; set; }
		public DateTime? ConfirmDate { get; set; }
		public bool? ConfirmStatus { get; set; }
		public string? ShippingAddress { get; set; }
		public int? PurchaseQuantity { get; set; }
		public DateTime? CreatedTime { get; set; }
		public DateTime? DeliveryTime { get; set; }
		public string? PurchaseDescription { get; set; }
		public bool? Confirmation { get; set; }
		public DateTime? ConfirmationTime { get; set; }
		public string? SupplierName { get; set; }
		public string? Adress { get; set; }
		public string? PhoneNumber { get; set; }
		public string? Email { get; set; }

	}
}
