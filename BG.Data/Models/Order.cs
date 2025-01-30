using System;
using System.Collections.Generic;

namespace BG.Data.Models;

public partial class Order
{
    public int Id { get; set; }

    public int? ProductId { get; set; }

    public DateTime? OrderDate { get; set; }

    public DateTime? ConfirmDate { get; set; }

    public bool? ConfirmStatus { get; set; }

    public string? ShippingAddress { get; set; }

    public virtual Product? Product { get; set; }
}
