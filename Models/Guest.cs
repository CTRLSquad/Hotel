using System;
using System.Collections.Generic;

namespace Hotel.Models;

public partial class Guest
{
    public int Id { get; set; }

    public string Fio { get; set; } = null!;

    public int RoomNumber { get; set; }

    public ulong IsVip { get; set; }

    public string PassportNumber { get; set; } = null!;
}
