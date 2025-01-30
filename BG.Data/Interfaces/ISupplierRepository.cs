using BG.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BG.Data.Interfaces
{
	public interface ISupplierRepository
	{
		Task<IEnumerable<Supplier?>> GetAllAsync();
		Task<Supplier?> GetByIdAsync(int id);
		Task AddAsync(Supplier supplier);
		Task UpdateAsync(Supplier supplier);
		Task DeleteAsync(int id);
	}
}
