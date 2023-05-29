using System;
using System.Collections.Generic;

namespace Hotel.Models;

public partial class Service
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? PriceTry { get; set; }
}
