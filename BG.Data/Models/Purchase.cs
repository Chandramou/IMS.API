using System;
using System.Collections.Generic;

namespace BG.Data.Models;

public partial class Purchase
{
    public int Id { get; set; }

    public int? ProductId { get; set; }

    public int? Quantity { get; set; }

    public DateTime? CreatedTime { get; set; }

    public DateTime? DeliveryTime { get; set; }

    public string? Description { get; set; }

    public bool? Confirmation { get; set; }

    public DateTime? ConfirmationTime { get; set; }

    public virtual Product? Product { get; set; }
}
