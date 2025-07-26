using System;
using System.Collections.Generic;

namespace API_PPE.Models;

public partial class VwUserlistIndex
{
    public int Iduser { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Fullname { get; set; }

    public string? Email { get; set; }

    public string StatusName { get; set; } = null!;

    public string? Image { get; set; }

    public string? Mobile { get; set; }

    public int? Isdelete { get; set; }
}
