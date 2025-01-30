using BG.Core.DTOs;
using BG.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BG.Core.Interfaces
{
	public interface ISupplierServices
	{
		Task<IEnumerable<Supplier?>> GetAllAsync();
		Task<Supplier?> GetByIdAsync(int id);
		Task AddAsync(Supplier supplier);
		Task UpdateAsync(int id, Supplier supplier);
		Task DeleteAsync(int id);
	}
}
