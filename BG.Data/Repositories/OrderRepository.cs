using BG.Data.Interfaces;
using BG.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BG.Data.Repositories
{
	public class OrderRepository : IOrderRepository
	{
		private readonly MyDbContext _dbcontext;
		public OrderRepository(MyDbContext dbcontext)
		{
			_dbcontext = dbcontext;
		}
		public async Task<IEnumerable<Order?>> GetAllAsync()
		{
			try
			{
				return await _dbcontext.Orders.ToListAsync();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
		public async Task<Order?> GetByIdAsync(int id)
		{
			try
			{
				return await _dbcontext.Orders.FirstOrDefaultAsync(p => p.Id == id);
			}
			
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
		public async Task AddAsync(Order order)
		{
			try
			{
				_dbcontext.Orders.Add(order);
				await _dbcontext.SaveChangesAsync();
			}

			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
		public async Task UpdateAsync(Order order)
		{
			try
			{
				_dbcontext.Orders.Update(order);
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
				var orders = await _dbcontext.Orders.FirstOrDefaultAsync(x => x.Id == id);
				if (orders != null)
				{
					_dbcontext.Orders.Remove(orders);
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
