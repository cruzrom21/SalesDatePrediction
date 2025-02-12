using System;
using System.Collections.Generic;

namespace Api.Gateway.Models;

public partial class GetEmployee
{
    public int Empid { get; set; }

    public string FullName { get; set; } = null!;
}
