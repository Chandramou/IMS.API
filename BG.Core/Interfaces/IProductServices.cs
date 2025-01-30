using BG.Core.DTOs;
using BG.Data.Models;

namespace BG.Core.Interfaces
{
	public interface IProductServices
	{
		Task<dynamic?> GetProductByBarcodeAsync(string barcode);
		Task<ProductDtos?> GetProductBySkuAsync(string sku);
		Task AddProductAsync(ProductDtos productDto);
	}
}
