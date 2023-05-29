using System;
using System.Collections.Generic;

namespace Hotel.Models;

public partial class User
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string IsStaff { get; set; } = null!;

    public int? IdGuests { get; set; }
}
