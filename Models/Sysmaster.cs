using System;
using System.Collections.Generic;

namespace API_PPE.Models;

public partial class Sysmaster
{
    public int Sysid { get; set; }

    public string Syscode { get; set; } = null!;

    public string Sysname { get; set; } = null!;

    public int Sysvalue { get; set; }

    public int Sysflag { get; set; }

    public string? Entryby { get; set; }

    public DateTime? Entrydate { get; set; }

    public virtual ICollection<Userlist> Userlists { get; set; } = new List<Userlist>();
}
