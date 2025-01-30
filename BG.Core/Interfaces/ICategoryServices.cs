using BG.Core.DTOs;
using BG.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BG.Core.Interfaces
{
	public interface ICategoryServices
	{
		Task<IEnumerable<Category?>> GetAllAsync();
		Task<Category?> GetByIdAsync(int id);
		Task AddAsync(Category category);
		Task UpdateAsync(int id, Category category);
		Task DeleteAsync(int id);

	}
}
