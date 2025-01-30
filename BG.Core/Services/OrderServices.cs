using BG.Core.Interfaces;
using BG.Data.Interfaces;
using BG.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BG.Core.Services
{
	public class OrderServices : IOrderServices
	{
		private readonly IOrderRepository _repository;
        public OrderServices(IOrderRepository repository)
        {
            _repository = repository;
        }
		public async Task<IEnumerable<Order?>> GetAllAsync()
		{
			try
			{
				return await _repository.GetAllAsync();
			}
			catch (Exception)
			{
				throw new Exception("Error retrieving all orders");
			}
		}
		public async Task<Order?> GetByIdAsync(int id)
		{
			try
			{
				return await _repository.GetByIdAsync(id);
			}
			catch (Exception)
			{
				throw new Exception("Error retrieving orders by ID");
			}
		}
		public async Task AddAsync(Order order)
		{
			try
			{
				var orders = new Order
				{
					Id = order.Id,
					OrderDate = order.OrderDate,
					ConfirmDate = order.ConfirmDate,
					ConfirmStatus = order.ConfirmStatus,
					ShippingAddress= order.ShippingAddress,

				};
				await _repository.AddAsync(orders);
			}
			catch (Exception)
			{
				throw new Exception("Error adding orders");
			}
		}
		public async Task UpdateAsync(int id, Order order)
		{
			try
			{
				var orders = await _repository.GetByIdAsync(id);
				if (orders == null)
				{
					throw new KeyNotFoundException($"orders with ID {id} not found.");
				}

				order.OrderDate = orders.OrderDate;
				order.ConfirmDate = orders.ConfirmDate;
				order.ConfirmStatus = orders.ConfirmStatus;
				order.ShippingAddress = orders.ShippingAddress;
				
				await _repository.UpdateAsync(orders);
			}
			catch (Exception)
			{
				throw new Exception("Error updating orders");
			}
		}
		public async Task DeleteAsync(int id)
		{
			try
			{
				await _repository.DeleteAsync(id);
			}
			catch (Exception)
			{
				throw new Exception("Error deleting orders");
			}
		}
	}
}
