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
	public class PurchaseServices : IPurchaseServices
	{
		private readonly IPurchaseRepository _repository;
        public PurchaseServices(IPurchaseRepository repository)
        {
            _repository = repository;
        }
		public async Task<IEnumerable<Purchase?>> GetAllAsync()
		{
			try
			{
				return await _repository.GetAllAsync();
			}
			catch (Exception)
			{
				throw new Exception("Error retrieving all purchases");
			}
		}
		public async Task<Purchase?> GetByIdAsync(int id)
		{
			try
			{
				return await _repository.GetByIdAsync(id);
			}
			catch (Exception)
			{
				throw new Exception("Error retrieving purchases by ID");
			}
		}
		public async Task AddAsync(Purchase purchase)
		{
			try
			{
				var purchases = new Purchase
				{
					Id = purchase.Id,
					Quantity = purchase.Quantity,
					CreatedTime = purchase.CreatedTime,
					DeliveryTime = purchase.DeliveryTime,
					Description = purchase.Description,
					Confirmation= purchase.Confirmation,
					ConfirmationTime= purchase.ConfirmationTime,

				};
				await _repository.AddAsync(purchases);
			}
			catch (Exception)
			{
				throw new Exception("Error adding purchased");
			}
		}
		public async Task UpdateAsync(int id, Purchase purchase)
		{
			try
			{
				var purchases = await _repository.GetByIdAsync(id);
				if (purchases == null)
				{
					throw new KeyNotFoundException($"purchased with ID {id} not found.");
				}

				purchase.Quantity = purchases.Quantity;
				purchase.CreatedTime = purchase.CreatedTime;
				purchase.DeliveryTime= purchase.DeliveryTime;
				purchase.Description = purchase.Description;
				purchase.Confirmation = purchase.Confirmation;
				purchase.ConfirmationTime = purchase.ConfirmationTime;

				await _repository.UpdateAsync(purchases);
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
