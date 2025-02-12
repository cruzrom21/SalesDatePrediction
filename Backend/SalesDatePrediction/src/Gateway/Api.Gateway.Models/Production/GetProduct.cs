using System;
using System.Collections.Generic;

namespace Api.Gateway.Models;

public partial class GetProduct
{
    public int Productid { get; set; }

    public string Productname { get; set; } = null!;
}
