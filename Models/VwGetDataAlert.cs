using System;
using System.Collections.Generic;

namespace API_PPE.Models;

public partial class VwGetDataAlert
{
    public long IdjsonDataH { get; set; }

    public DateTime Timestamp { get; set; }

    public string CameraId { get; set; } = null!;

    public string Images { get; set; } = null!;

    public double Score { get; set; }

    public string? Fauls { get; set; }
}
