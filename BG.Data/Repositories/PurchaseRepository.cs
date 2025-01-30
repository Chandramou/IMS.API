using BG.Data.Interfaces;
using BG.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BG.Data.Repositories
{
	public class PurchaseRepository : IPurchaseRepository
	{
		private readonly MyDbContext _dbcontext;
		public PurchaseRepository(MyDbContext dbcontext)
		{
			_dbcontext = dbcontext;
		}
		public async Task<IEnumerable<Purchase?>> GetAllAsync()
		{
			try
			{
				return await _dbcontext.Purchases.ToListAsync();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
		public async Task<Purchase?> GetByIdAsync(int id)
		{
			try
			{
				return await _dbcontext.Purchases.FirstOrDefaultAsync(p => p.Id == id);
			}

			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
		public async Task AddAsync(Purchase purchase)
		{
			try
			{
				_dbcontext.Purchases.Add(purchase);
				await _dbcontext.SaveChangesAsync();
			}

			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
		public async Task UpdateAsync(Purchase purchase)
		{
			try
			{
				_dbcontext.Purchases.Update(purchase);
				await _dbcontext.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
		public async Task DeleteAsync(int id)
		{
			try
			{
				var purchase = await _dbcontext.Purchases.FirstOrDefaultAsync(x => x.Id == id);
				if (purchase != null)
				{
					_dbcontext.Purchases.Remove(purchase);
					await _dbcontext.SaveChangesAsync();
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
