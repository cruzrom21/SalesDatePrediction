using System;
using System.Collections.Generic;

namespace HR.Models.Domain;

public partial class GetEmployee
{
    public int Empid { get; set; }

    public string FullName { get; set; } = null!;
}
