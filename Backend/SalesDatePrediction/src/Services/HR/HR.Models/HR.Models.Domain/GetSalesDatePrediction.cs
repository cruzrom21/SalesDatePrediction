using System;
using System.Collections.Generic;

namespace HR.Models.Domain;

public partial class GetSalesDatePrediction
{
    public string CustomerName { get; set; } = null!;

    public DateTime? LastOrderDate { get; set; }

    public DateTime? NextPredictedOrder { get; set; }
}
