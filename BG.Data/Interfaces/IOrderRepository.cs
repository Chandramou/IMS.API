using BG.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BG.Data.Interfaces
{
	public interface IOrderRepository
	{
		Task<IEnumerable<Order?>> GetAllAsync();
		Task<Order?> GetByIdAsync(int id);
		Task AddAsync(Order order);
		Task UpdateAsync(Order order);
		Task DeleteAsync(int id);
	}
}
