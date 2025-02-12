using System;
using System.Collections.Generic;

namespace Api.Gateway.Models;

public partial class GetShipper
{
    public int Shipperid { get; set; }

    public string Companyname { get; set; } = null!;
}
