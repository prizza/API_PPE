using System;
using System.Collections.Generic;

namespace API_PPE.Models;

public partial class JsonDataH
{
    public long IdjsonDataH { get; set; }

    public DateTime Timestamp { get; set; }

    public string CameraId { get; set; } = null!;

    public string CameraIp { get; set; } = null!;

    public string ComputerIp { get; set; } = null!;

    public string Images { get; set; } = null!;

    public DateTime? Entrydate { get; set; }

    public virtual ICollection<JsonDataD> JsonDataDs { get; set; } = new List<JsonDataD>();
}
