using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sales.Models.Domain;

public partial class GetSalesDatePrediction
{
	public int custid { get; set; }
	public string CustomerName { get; set; } = null!;
	public DateTime? LastOrderDate { get; set; }
    public DateTime? NextPredictedOrder { get; set; }
}
