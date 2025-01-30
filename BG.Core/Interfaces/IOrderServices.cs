using BG.Data.Models;

namespace BG.Core.Interfaces
{
	public interface IOrderServices
	{
		Task<IEnumerable<Order?>> GetAllAsync();
		Task<Order?> GetByIdAsync(int id);
		Task AddAsync(Order order);
		Task UpdateAsync(int id, Order order);
		Task DeleteAsync(int id);
	}
}
