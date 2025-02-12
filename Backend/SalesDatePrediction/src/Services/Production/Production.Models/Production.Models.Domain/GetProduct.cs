using System;
using System.Collections.Generic;

namespace Production.Models.Domain;

public partial class GetProduct
{
    public int Productid { get; set; }

    public string Productname { get; set; } = null!;
}
