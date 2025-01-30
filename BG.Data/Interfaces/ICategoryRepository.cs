using BG.Data.Models;

namespace BG.Data.Interfaces
{
	public interface ICategoryRepository
	{

		Task<IEnumerable<Category?>> GetAllAsync();
		Task<Category?> GetByIdAsync(int id);
		Task AddAsync(Category category);
		Task UpdateAsync(Category category);
		Task DeleteAsync(int id);
	}
}
