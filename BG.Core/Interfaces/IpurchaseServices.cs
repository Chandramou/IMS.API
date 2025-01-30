using BG.Data.Models;

namespace BG.Core.Interfaces
{
	public interface IPurchaseServices
	{
		Task<IEnumerable<Purchase?>> GetAllAsync();
		Task<Purchase?> GetByIdAsync(int id);
		Task AddAsync(Purchase purchase);
		Task UpdateAsync(int id, Purchase purchase);
		Task DeleteAsync(int id);
	}
}
