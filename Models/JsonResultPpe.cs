using System;
using System.Collections.Generic;

namespace API_PPE.Models;

public partial class JsonResultPpe
{
    public long IdjsonRestPpe { get; set; }

    public long IdjsonDataD { get; set; }

    public string Bboxs { get; set; } = null!;

    public string Labels { get; set; } = null!;

    public double Scores { get; set; }

    public string Fauls { get; set; } = null!;

    public DateTime? Entrydate { get; set; }
}
