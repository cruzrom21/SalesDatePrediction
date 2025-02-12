using System;
using System.Collections.Generic;

namespace Production.Models.Domain;

public partial class GetShipper
{
    public int Shipperid { get; set; }

    public string Companyname { get; set; } = null!;
}
