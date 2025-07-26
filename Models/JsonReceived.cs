using System;
using System.Collections.Generic;

namespace API_PPE.Models;

public partial class JsonReceived
{
    public long IdjsonReceived { get; set; }

    public string JsonName { get; set; } = null!;

    public string JsonValue { get; set; } = null!;

    public int? Isprocessed { get; set; }

    public DateTime? Entrydate { get; set; }
}
