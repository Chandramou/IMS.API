using BG.Data.Interfaces;
using BG.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BG.Data.Repositories
{
	public class SupplierRepository : ISupplierRepository
	{
		private readonly MyDbContext _context;
		public SupplierRepository(MyDbContext context)
		{
			_context = context;
		}
		public async Task<IEnumerable<Supplier?>> GetAllAsync()
		{
			try
			{
				return await _context.Suppliers.ToListAsync();
			}
			catch (Exception ex)
			{
				throw new Exception("An error occurred while getting suppliers.", ex);
			}
		}
		public async Task<Supplier?> GetByIdAsync(int id)
		{
			try
			{
				return await _context.Suppliers.FindAsync(id);
			}
			catch (Exception ex)
			{
				throw new Exception("An error occurred while getting the supplier by ID.", ex);
			}
		}
		public async Task AddAsync(Supplier supplier)
		{
			try
			{
				_context.Suppliers.Add(supplier);
				await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				throw new Exception("An error occurred while adding the supplier.", ex);
			}
		}
		public async Task UpdateAsync(Supplier supplier)
		{
			try
			{
				_context.Suppliers.Update(supplier);
				await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				throw new Exception("An error occurred while updating the supplier.", ex);
			}
		}
		public async Task DeleteAsync(int id)
		{
			try
			{
				var supplier = await _context.Suppliers.FindAsync(id);
				if (supplier != null)
				{
					_context.Suppliers.Remove(supplier);
					await _context.SaveChangesAsync();
				}
			}
			catch (Exception ex)
			{
				throw new Exception("An error occurred while deleting the supplier.", ex);
			}
		}
	}
}
