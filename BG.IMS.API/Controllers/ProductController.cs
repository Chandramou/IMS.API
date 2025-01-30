using BG.Core.DTOs;
using BG.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
	private readonly IProductServices _productServices;

	public ProductController(IProductServices productServices)
	{
		_productServices = productServices;
	}

	// Add a new product
	[HttpPost]
	public async Task<IActionResult> AddProduct([FromBody] ProductDtos productDto)
	{
		if (productDto == null)
		{
			return BadRequest("Invalid product data.");
		}
		try
		{
			await _productServices.AddProductAsync(productDto);
			return Ok("Product added successfully.");
		}
		catch (Exception ex)
		{
			return StatusCode(500, $"Error: {ex.Message}");
		}
	}

	[HttpGet("barcode/{barcode}")]
	public async Task<IActionResult> GetByBarcode(string barcode)
	{
		try
		{
			byte[] qrCode = await _productServices.GetProductByBarcodeAsync(barcode);
			
			if (qrCode == null || qrCode.Length == 0)
			{
				return NotFound("Product not found or QR code generation failed.");
			}
			
			string contentType = "image/png";
			return new FileContentResult(qrCode, contentType);
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}

	[HttpGet("sku/{sku}")]
	public async Task<IActionResult> GetBySku(string sku)
	{
		try
		{
			var product = await _productServices.GetProductBySkuAsync(sku);
			
			if (product == null)
			{
				return NotFound("Product not found.");
			}

			return Ok(product);
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}
}