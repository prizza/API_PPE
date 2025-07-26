using System;
using System.Collections.Generic;

namespace API_PPE.Models;

public partial class Userlist
{
    public int Iduser { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Fullname { get; set; }

    public DateOnly? Dob { get; set; }

    public string? Email { get; set; }

    public int Status { get; set; }

    public string? Image { get; set; }

    public string? Entryby { get; set; }

    public DateTime? Entrydate { get; set; }

    public string? Updateby { get; set; }

    public DateTime? Updatedate { get; set; }

    public string? Mobile { get; set; }

    public int? Isdelete { get; set; }

    public DateTime? Deletedate { get; set; }

    public virtual Sysmaster StatusNavigation { get; set; } = null!;
}
