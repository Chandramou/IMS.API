using BG.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BG.Data.Interfaces
{
	public interface IProductRepository
	{
		Task<Product?> GetByBarcodeAsync(string barcode);
		Task<Product?> GetBySkuAsync(string sku);
		Task AddAsync(Product product);
	}
}
