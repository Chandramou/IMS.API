using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BG.Core.DTOs
{
	public class ProductDtos
	{
		public int ProductId { get; set; }
		public string? Name { get; set; }
		public string? BarCode { get; set; }
		public string? Sku { get; set; }
		public decimal? SellingPrice { get; set; }
		public decimal? PurchasingPrice { get; set; }
		public int? Quantity { get; set; }
		public int? CategoryId { get; set; }
		public int? SupplierId { get; set; }

	}
}
