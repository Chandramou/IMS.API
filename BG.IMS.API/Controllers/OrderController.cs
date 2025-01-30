using BG.Core.DTOs;
using BG.Core.Interfaces;
using BG.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BG.IMS.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private readonly IOrderServices _service;

		public OrderController(IOrderServices service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<ActionResult> GetAll()
		{
			try
			{
				var controller = await _service.GetAllAsync();
				return Ok(controller);
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
				var controller = await _service.GetByIdAsync(id);
				if (controller == null)
				{
					return NotFound();
				}
				return Ok(controller);
			}
			catch (Exception ex)
			{
				return Ok(ex.Message);
			}
		}

		[HttpPost]
		public async Task<IActionResult> AddSupplier([FromBody] OrderDtos orderDtos)
		{
			if (orderDtos == null)
			{
				return BadRequest("Supplier data is required.");
			}

			try
			{
				var order = new Order
				{
					ProductId = orderDtos.ProductId,
					OrderDate = orderDtos.OrderDate,
					ConfirmDate = orderDtos.ConfirmDate,
					ConfirmStatus = orderDtos.ConfirmStatus,
					ShippingAddress = orderDtos.ShippingAddress,
				};
				await _service.AddAsync(order);

				var result = new OrderDtos
				{
					Id = order.Id,
					ProductId = order.ProductId,
					OrderDate = order.OrderDate,
					ConfirmDate = order.ConfirmDate,
					ConfirmStatus = order.ConfirmStatus,
					ShippingAddress = order.ShippingAddress,
				};

				return Ok(result);
			}
			catch (Exception ex)
			{
				return Ok(ex.Message);
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateSupplier(int id, [FromBody] OrderDtos orderDtos)
		{
			if (orderDtos == null)
			{
				return BadRequest("Supplier data is required.");
			}

			try
			{
				var order = new Order
				{
					Id = id,
					ProductId = orderDtos.ProductId,
					OrderDate = orderDtos.OrderDate,
					ConfirmDate= orderDtos.ConfirmDate,
					ConfirmStatus = orderDtos.ConfirmStatus,
					ShippingAddress= orderDtos.ShippingAddress,
				};

				await _service.UpdateAsync(id, order);

				return Ok(new OrderDtos
				{
					Id= order.Id,
					ProductId= order.ProductId,
					OrderDate = order.OrderDate,
					ConfirmDate= order.ConfirmDate,
					ConfirmStatus = order.ConfirmStatus,
					ShippingAddress= order.ShippingAddress,

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
				var order = await _service.GetByIdAsync(id);
				if (order == null)
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
