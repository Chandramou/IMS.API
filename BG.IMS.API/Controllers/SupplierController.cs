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
	public class SupplierController : ControllerBase
	{
		private readonly ISupplierServices _service;

		public SupplierController(ISupplierServices service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<ActionResult> GetAll()
		{
			try
			{
				var suppliers = await _service.GetAllAsync();
				return Ok(suppliers);
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
				var supplier = await _service.GetByIdAsync(id);
				if (supplier == null)
				{
					return NotFound();
				}
				return Ok(supplier);
			}
			catch (Exception ex)
			{
				return Ok(ex.Message);
			}
		}

		[HttpPost]
		public async Task<IActionResult> AddSupplier([FromBody] SupplierDtos supplierDtos)
		{
			if (supplierDtos == null)
			{
				return BadRequest("Supplier data is required.");
			}

			try
			{
				var supplier = new Supplier
				{
					Name = supplierDtos.Name,
					PhoneNumber = supplierDtos.PhoneNumber,
					Adress = supplierDtos.Address,
					Email = supplierDtos.Email,
				};
				await _service.AddAsync(supplier);

				var result = new SupplierDtos
				{
					Id = supplier.Id,
					Name = supplier.Name,
					PhoneNumber = supplier.PhoneNumber,
					Address = supplier.Adress,
					Email = supplier.Email,
				};

				return Ok(result);
			}
			catch (Exception ex)
			{
				return Ok(ex.Message);
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateSupplier(int id, [FromBody] SupplierDtos supplierDtos)
		{
			if (supplierDtos == null)
			{
				return BadRequest("Supplier data is required.");
			}

			try
			{
				var supplier = new Supplier
				{
					Id = id,
					Name = supplierDtos.Name,
					PhoneNumber = supplierDtos.PhoneNumber,
					Adress = supplierDtos.Address,
					Email = supplierDtos.Email,
				};

				await _service.UpdateAsync(id, supplier);

				return Ok(new SupplierDtos
				{
					Id = supplier.Id,
					Name = supplier.Name,
					PhoneNumber = supplier.PhoneNumber,
					Address = supplier.Adress,
					Email = supplier.Email
				});
			}
			catch (Exception ex)
			{
				return Ok(ex.Message);
			}
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteSupplier(int id)
		{
			try
			{
				var supplier = await _service.GetByIdAsync(id);
				if (supplier == null)
				{
					return NotFound();
				}

				await _service.DeleteAsync(id);

				return Ok($"Supplier with ID {id} has been deleted.");
			}
			catch (Exception ex)
			{
				return Ok(ex.Message);
			}
		}
	}

}
