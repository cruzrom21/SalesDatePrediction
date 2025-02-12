using System;
using System.Collections.Generic;

namespace HR.Models.Domain;

public partial class GetClientOrder
{
    public int Orderid { get; set; }

    public int? Custid { get; set; }

    public DateTime Requireddate { get; set; }

    public DateTime? Shippeddate { get; set; }

    public string Shipname { get; set; } = null!;

    public string Shipaddress { get; set; } = null!;

    public string Shipcity { get; set; } = null!;
}
