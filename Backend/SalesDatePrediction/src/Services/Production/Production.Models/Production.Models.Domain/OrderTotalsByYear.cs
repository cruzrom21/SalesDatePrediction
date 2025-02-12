using System;
using System.Collections.Generic;

namespace Production.Models.Domain;

public partial class OrderTotalsByYear
{
    public int? Orderyear { get; set; }

    public int? Qty { get; set; }
}
