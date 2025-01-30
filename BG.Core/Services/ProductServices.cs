using BG.Core.DTOs;
using BG.Core.Interfaces;
using BG.Data.Interfaces;
using BG.Data.Models;
using Newtonsoft.Json;
using QRCoder;

public class ProductServices : IProductServices
{
	private readonly IProductRepository _productRepository;

	public ProductServices(IProductRepository productRepository)
	{
		_productRepository = productRepository;
	}

	public async Task<dynamic?> GetProductByBarcodeAsync(string barcode)
	{
		try
		{
			var product = await _productRepository.GetByBarcodeAsync(barcode);
			if (product == null)
			{
				return null;
			}

			var productDto = new ProductDetailsDtos
			{
				ProductId = product.Id,
				Name = product.Name,
				Sku = product.Sku,
				BarCode = product.BarCode,
				SellingPrice = product.SellingPrice,
				PurchasingPrice = product.PurchasingPrice,
				Quantity = product.Quantity,
				CategoryId = product.Category?.Id ?? 0,
				CategoryName = product.Category?.Name,
				Description = product.Category?.Description,
				SupplierId = product.Supplier?.Id ?? 0,
				SupplierName = product.Supplier?.Name,
				PhoneNumber = product.Supplier?.PhoneNumber,
				Adress = product.Supplier?.Adress,
				Email = product.Supplier?.Email,
				OrderDate = product.Orders?.FirstOrDefault()?.OrderDate,
				ConfirmDate = product.Orders?.FirstOrDefault()?.ConfirmDate,
				ConfirmStatus = product.Orders?.FirstOrDefault()?.ConfirmStatus,
				ShippingAddress = product.Orders?.FirstOrDefault()?.ShippingAddress,
				PurchaseQuantity = product.Purchases?.Max(x => x.Quantity),
				CreatedTime = product.Purchases?.LastOrDefault()?.CreatedTime,
				DeliveryTime = product.Purchases?.LastOrDefault()?.DeliveryTime
			};

			// Convert productDto to JSON string
			var productDtoJson = JsonConvert.SerializeObject(productDto);

			// Generate QR code
			var qrGenerator = new QRCodeGenerator();
			var qrCodeData = qrGenerator.CreateQrCode(productDtoJson, QRCodeGenerator.ECCLevel.Q);
			var qrCode = new BitmapByteQRCode(qrCodeData);
			byte[] qrCodeBitmap = qrCode.GetGraphic(3);

			return qrCodeBitmap;  // Ensure the client handles the image
		}
		catch (Exception ex)
		{
			throw new Exception("An error occurred while getting the product.", ex);
		}
	}

	public async Task<ProductDtos?> GetProductBySkuAsync(string sku)
	{
		try
		{
			var product = await _productRepository.GetBySkuAsync(sku);
			if (product == null)
			{
				return null;
			}

			var productDto = new ProductDetailsDtos
			{
				ProductId = product.Id,
				Name = product.Name,
				Sku = product.Sku,
				BarCode = product.BarCode,
				SellingPrice = product.SellingPrice,
				PurchasingPrice = product.PurchasingPrice,
				Quantity = product.Quantity,
				CategoryId = product.Category?.Id ?? 0,
				CategoryName = product.Category?.Name,
				Description = product.Category?.Description,
				SupplierId = product.Supplier?.Id ?? 0,
				SupplierName = product.Supplier?.Name,
				PhoneNumber = product.Supplier?.PhoneNumber,
				Adress = product.Supplier?.Adress,
				Email = product.Supplier?.Email,
				OrderDate = product.Orders?.FirstOrDefault()?.OrderDate,
				ConfirmDate = product.Orders?.FirstOrDefault()?.ConfirmDate,
				ConfirmStatus = product.Orders?.FirstOrDefault()?.ConfirmStatus,
				ShippingAddress = product.Orders?.FirstOrDefault()?.ShippingAddress,
				PurchaseQuantity = product.Purchases?.Max(x => x.Quantity),
				CreatedTime = product.Purchases?.LastOrDefault()?.CreatedTime,
				DeliveryTime = product.Purchases?.LastOrDefault()?.DeliveryTime
			};

			return productDto;
		}
		catch (Exception ex)
		{
			throw new Exception("An error occurred while getting the product.", ex);
		}
	}

	public async Task AddProductAsync(ProductDtos productDto)
	{
		try
		{
			var product = new Product
			{
				Id = productDto.ProductId,
				Name = productDto.Name,
				Sku = productDto.Sku,
				BarCode = productDto.BarCode,
				SellingPrice = productDto.SellingPrice,
				PurchasingPrice = productDto.PurchasingPrice,
				Quantity = productDto.Quantity,
				CategoryId = productDto.CategoryId,
				SupplierId = productDto.SupplierId
			};

			await _productRepository.AddAsync(product);
		}
		catch (Exception ex)
		{
			throw new Exception($"An error occurred while adding the product: {ex.Message}.", ex);
		}
	}
}