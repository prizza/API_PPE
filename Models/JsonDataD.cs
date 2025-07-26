using System;
using System.Collections.Generic;

namespace API_PPE.Models;

public partial class JsonDataD
{
    public long IdjsonDataD { get; set; }

    public long IdjsonDataH { get; set; }

    public string Bbox { get; set; } = null!;

    public string Label { get; set; } = null!;

    public double Score { get; set; }

    public DateTime? Entrydate { get; set; }

    public virtual JsonDataH IdjsonDataHNavigation { get; set; } = null!;
}
