using BG.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BG.Data.Interfaces
{
	public interface IPurchaseRepository
	{
		Task<IEnumerable<Purchase?>> GetAllAsync();
		Task<Purchase?> GetByIdAsync(int id);
		Task AddAsync(Purchase purchase);
		Task UpdateAsync(Purchase purchase);
		Task DeleteAsync(int id);
	}
}
