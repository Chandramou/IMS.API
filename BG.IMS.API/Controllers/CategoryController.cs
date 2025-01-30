using BG.Core.DTOs;
using BG.Core.Interfaces;
using BG.Core.Services;
using BG.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BG.IMS.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly ICategoryServices _categoryService;
		public CategoryController(ICategoryServices categoryService)
		{
			_categoryService = categoryService;
		}


		[HttpGet]
		public async Task<ActionResult> GetAll()
		{
			try
			{
				var categories = await _categoryService.GetAllAsync();
				return Ok(categories);
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			try
			{
				var category = await _categoryService.GetByIdAsync(id);
				if (category == null)
				{
					return NotFound();
				}
				return Ok(category);
			}
			catch (Exception ex)
			{
				return Ok(ex.Message);
			}
		}
		[HttpPost]
		public async Task<IActionResult> AddCategory([FromBody] CategoryDtos categoryDto)
		{
			if (categoryDto == null)
			{
				return BadRequest("Category data is required.");
			}

			try
			{
				var category = new Category
				{
					Name = categoryDto.CategoryName,
					Description = categoryDto.Description,
				};
				await _categoryService.AddAsync(category);
				var result = new CategoryDtos
				{
					CategoryId = category.Id,
					CategoryName = category.Name,
					Description = categoryDto.Description,
				};

				return Ok(result);
			}
			catch (Exception ex)
			{
				return Ok(ex.Message);
			}
		}
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryDtos categoryDto)
		{

			try
			{
				var category = await _categoryService.GetByIdAsync(id);
				if (category == null)
				{
					return NotFound("Category not found.");
				}
				category.Name = categoryDto.CategoryName;
				category.Description = categoryDto.Description;

				await _categoryService.UpdateAsync(id,category);

				return Ok(new CategoryDtos
				{
					CategoryId = category.Id,
					CategoryName = category.Name,
					Description = category.Description,
				});
			}
			catch (Exception ex)
			{
				return Ok(ex.Message);
			}
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteCategory(int id)
		{
			try
			{
				var category = await _categoryService.GetByIdAsync(id);
				if (category == null)
				{
					return NotFound("Category not found.");
				}

				await _categoryService.DeleteAsync(id);
				return Ok($"Category with ID {id} has been deleted.");
			}
			catch (Exception ex)
			{
				return Ok(ex.Message);
			}
		}
	}
}
