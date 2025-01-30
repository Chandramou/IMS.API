using BG.Data.Interfaces;
using BG.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BG.Data.Repositories
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly MyDbContext _context;
		public CategoryRepository(MyDbContext context)
		{
			_context = context;
		}
		public async Task<IEnumerable<Category?>> GetAllAsync()
		{
			try
			{
				return await _context.Categories.ToListAsync();
			}
			catch (Exception ex)
			{
				throw new Exception("An error occurred while getting categories.", ex);
			}
		}
		public async Task<Category?> GetByIdAsync(int id)
		{
			try
			{
				return await _context.Categories.FindAsync(id);
			}
			catch (Exception ex)
			{
				throw new Exception("An error occurred while getting the category by ID.", ex);
			}
		}
		public async Task AddAsync(Category category)
		{
			try
			{
				_context.Categories.Add(category);
				await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				throw new Exception("An error occurred while adding the category.", ex);
			}
		}
		public async Task UpdateAsync(Category category)
		{
			try
			{
				_context.Categories.Update(category);
				await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				throw new Exception("An error occurred while updating the category.", ex);
			}
		}
		public async Task DeleteAsync(int id)
		{
			try
			{
				var category = await _context.Categories.FindAsync(id);
				if (category != null)
				{
					_context.Categories.Remove(category);
					await _context.SaveChangesAsync();
				}
			}
			catch (Exception ex)
			{
				throw new Exception("An error occurred while deleting the category.", ex);
			}
		}
	}
}
