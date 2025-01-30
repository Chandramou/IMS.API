using System;
using System.Collections.Generic;

namespace BG.Data.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? BarCode { get; set; }

    public string? Sku { get; set; }

    public decimal? SellingPrice { get; set; }

    public decimal? PurchasingPrice { get; set; }

    public int? Quantity { get; set; }

    public int? CategoryId { get; set; }

    public int? SupplierId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();

    public virtual Supplier? Supplier { get; set; }
}
