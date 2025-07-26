using System;
using System.Collections.Generic;

namespace API_PPE.Models;

public partial class Activitylog
{
    public long Idact { get; set; }

    public string Comname { get; set; } = null!;

    public string Frmname { get; set; } = null!;

    public string Actname { get; set; } = null!;

    public string? Olddata { get; set; }

    public string? Newdata { get; set; }

    public string? Entryby { get; set; }

    public DateTime? Entrydate { get; set; }
}
