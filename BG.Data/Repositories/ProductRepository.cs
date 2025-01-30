using BG.Data.Interfaces;
using BG.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BG.Data.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private readonly MyDbContext _context;

		public ProductRepository(MyDbContext context)
		{
			_context = context;
		}
		public async Task<Product?> GetByBarcodeAsync(string barcode)
		{
			try
			{
				return await _context.Products
					.Include(p => p.Category)
					.Include(p => p.Supplier)
					.Include(p => p.Orders)
					.Include(p => p.Purchases) // Include Purchases if needed
					.FirstOrDefaultAsync(p => p.BarCode == barcode);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<Product?> GetBySkuAsync(string sku)
		{
			try
			{
				return await _context.Products
					.Include(p => p.Category)
					.Include(p => p.Supplier)
					.Include(p => p.Orders)
					.Include(p => p.Purchases) // Include Purchases if needed
					.FirstOrDefaultAsync(p => p.Sku == sku);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
 		public async Task AddAsync(Product product)
		{
			try
			{
				_context.Products.Add(product);
				await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}