using System;
using System.Collections.Generic;

namespace API_PPE.Models;

public partial class Apiclient
{
    public int Idclient { get; set; }

    public string Clientname { get; set; } = null!;

    public string Apitoken { get; set; } = null!;

    public bool Isactive { get; set; }

    public DateTime Entrydate { get; set; }
}
