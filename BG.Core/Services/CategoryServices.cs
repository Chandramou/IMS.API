using BG.Core.DTOs;
using BG.Core.Interfaces;
using BG.Data.Interfaces;
using BG.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BG.Core.Services
{
	public class CategoryServices : ICategoryServices
	{
		private readonly ICategoryRepository _repository;
		public CategoryServices(ICategoryRepository repository)
		{
			_repository = repository;
		}
		public async Task<IEnumerable<Category?>> GetAllAsync()
		{
			try
			{
				return await _repository.GetAllAsync();
			}
			catch (Exception)
			{
				throw new Exception("Error retrieving all categories");
			}
		}
		public async Task<Category?> GetByIdAsync(int id)
		{
			try
			{
				return await _repository.GetByIdAsync(id);
			}
			catch (Exception)
			{
				throw new Exception("Error retrieving category by ID");
			}
		}
		public async Task AddAsync(Category category)
		{
			try
			{
				var category1 = new Category
				{
					Id = category.Id,
					Name = category.Name,
					Description = category.Description,
				};
				await _repository.AddAsync(category);
			}
			catch (Exception)
			{
				throw new Exception("Error adding category");
			}
		}
		public async Task UpdateAsync(int id, Category category)
		{
			try
			{
				var category1 = await _repository.GetByIdAsync(id);
				if (category1 == null)
				{
					throw new KeyNotFoundException($"Category with ID {id} not found.");
				}

				category.Name = category.Name;
				category.Description = category.Description;
				await _repository.UpdateAsync(category);
			}
			catch (Exception)
			{
				throw new Exception("Error updating category");
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
				throw new Exception("Error deleting category");
			}
		}
	}
}

