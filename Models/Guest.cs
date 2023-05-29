using System;
using System.Collections.Generic;

namespace Hotel.Models;

public partial class Guest
{
    public int Id { get; set; }

    public string Fio { get; set; } = null!;

    public int RoomNumber { get; set; }

    public string IsVip { get; set; } = null!;

    public string PassportNumber { get; set; } = null!;
}
