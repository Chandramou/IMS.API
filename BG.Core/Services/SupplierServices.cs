using BG.Core.DTOs;
using BG.Core.Interfaces;
using BG.Data.Interfaces;
using BG.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BG.Core.Services
{
	public class SupplierServices : ISupplierServices
	{
		private readonly ISupplierRepository _repository;
		public SupplierServices(ISupplierRepository repository)
		{
			_repository = repository;
		}
		public async Task<IEnumerable<Supplier?>> GetAllAsync()
		{
			try
			{
				return await _repository.GetAllAsync();
			}
			catch (Exception)
			{
				throw new Exception();
			}
		}
		public async Task<Supplier?> GetByIdAsync(int id)
		{
			try
			{
				return await _repository.GetByIdAsync(id);
			}
			catch (Exception)
			{
				throw new Exception();
			}
		}
		public async Task AddAsync(Supplier supplier)
		{
			try
			{
				var supplier1 = new Supplier
				{
					Id = supplier.Id,
					Name = supplier.Name,
					Adress=supplier.Adress,
					PhoneNumber = supplier.PhoneNumber,
					Email = supplier.Email,
				};
				await _repository.AddAsync(supplier);
			}
			catch (Exception)
			{
				throw new Exception();
			}
		}
		public async Task UpdateAsync(int id, Supplier supplier)
		{
			try
			{
				var supplier1 = await _repository.GetByIdAsync(id);
				if (supplier == null)
				{
					throw new Exception();
				}
				supplier.Name = supplier.Name;
				supplier.Adress = supplier.Adress;
				supplier.PhoneNumber = supplier.PhoneNumber;
				supplier.Email = supplier.Email;

				await _repository.UpdateAsync(supplier);
			}
			catch (Exception)
			{
				throw new Exception();
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
				throw new Exception();
			}
		}
	}
}
